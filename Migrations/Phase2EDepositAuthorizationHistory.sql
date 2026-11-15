USE `smart_cash_db`;

SET @authorized_by_column_exists = (
	SELECT COUNT(*)
	FROM information_schema.COLUMNS
	WHERE TABLE_SCHEMA = DATABASE()
	  AND TABLE_NAME = 'transactions'
	  AND COLUMN_NAME = 'authorized_by_user_id'
);
SET @sql = IF(
	@authorized_by_column_exists = 0,
	'ALTER TABLE `transactions` ADD COLUMN `authorized_by_user_id` INT NULL',
	'SELECT 1'
);
PREPARE migration_statement FROM @sql;
EXECUTE migration_statement;
DEALLOCATE PREPARE migration_statement;

SET @authorized_by_index_exists = (
	SELECT COUNT(*)
	FROM information_schema.STATISTICS
	WHERE TABLE_SCHEMA = DATABASE()
	  AND TABLE_NAME = 'transactions'
	  AND COLUMN_NAME = 'authorized_by_user_id'
	  AND SEQ_IN_INDEX = 1
);
SET @sql = IF(
	@authorized_by_index_exists = 0,
	'ALTER TABLE `transactions` ADD INDEX `idx_transactions_authorized_by_user_id` (`authorized_by_user_id`)',
	'SELECT 1'
);
PREPARE migration_statement FROM @sql;
EXECUTE migration_statement;
DEALLOCATE PREPARE migration_statement;

SET @authorized_by_foreign_key_exists = (
	SELECT COUNT(*)
	FROM information_schema.KEY_COLUMN_USAGE
	WHERE TABLE_SCHEMA = DATABASE()
	  AND TABLE_NAME = 'transactions'
	  AND COLUMN_NAME = 'authorized_by_user_id'
	  AND REFERENCED_TABLE_SCHEMA = DATABASE()
	  AND REFERENCED_TABLE_NAME = 'users'
	  AND REFERENCED_COLUMN_NAME = 'id'
);
SET @sql = IF(
	@authorized_by_foreign_key_exists = 0,
	'ALTER TABLE `transactions` ADD CONSTRAINT `fk_transactions_authorized_by_user_id` FOREIGN KEY (`authorized_by_user_id`) REFERENCES `users` (`id`)',
	'SELECT 1'
);
PREPARE migration_statement FROM @sql;
EXECUTE migration_statement;
DEALLOCATE PREPARE migration_statement;
