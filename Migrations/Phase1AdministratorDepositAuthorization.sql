USE `smart_cash_db`;

SET @users_role_exists = (
	SELECT COUNT(*)
	FROM information_schema.COLUMNS
	WHERE TABLE_SCHEMA = DATABASE()
	  AND TABLE_NAME = 'users'
	  AND COLUMN_NAME = 'role'
);
SET @sql = IF(
	@users_role_exists = 0,
	'ALTER TABLE `users` ADD COLUMN `role` VARCHAR(20) NOT NULL DEFAULT ''user''',
	'SELECT 1'
);
PREPARE migration_statement FROM @sql;
EXECUTE migration_statement;
DEALLOCATE PREPARE migration_statement;

SET @users_is_active_exists = (
	SELECT COUNT(*)
	FROM information_schema.COLUMNS
	WHERE TABLE_SCHEMA = DATABASE()
	  AND TABLE_NAME = 'users'
	  AND COLUMN_NAME = 'is_active'
);
SET @sql = IF(
	@users_is_active_exists = 0,
	'ALTER TABLE `users` ADD COLUMN `is_active` BOOLEAN NOT NULL DEFAULT TRUE',
	'SELECT 1'
);
PREPARE migration_statement FROM @sql;
EXECUTE migration_statement;
DEALLOCATE PREPARE migration_statement;

UPDATE `users`
SET `role` = 'user'
WHERE `role` IS NULL
   OR BINARY `role` NOT IN (BINARY 'user', BINARY 'admin');

UPDATE `users`
SET `is_active` = TRUE
WHERE `is_active` IS NULL;

ALTER TABLE `users`
	MODIFY COLUMN `role` VARCHAR(20) NOT NULL DEFAULT 'user',
	MODIFY COLUMN `is_active` BOOLEAN NOT NULL DEFAULT TRUE;

SET @mariadb_version_major = CAST(SUBSTRING_INDEX(SUBSTRING_INDEX(VERSION(), '-', 1), '.', 1) AS UNSIGNED);
SET @mariadb_version_minor = CAST(SUBSTRING_INDEX(SUBSTRING_INDEX(VERSION(), '-', 1), '.', -2) AS UNSIGNED);
SET @mariadb_version_patch = CAST(SUBSTRING_INDEX(SUBSTRING_INDEX(VERSION(), '-', 1), '.', -1) AS UNSIGNED);
SET @role_check_exists = (
	SELECT COUNT(*)
	FROM information_schema.TABLE_CONSTRAINTS
	WHERE CONSTRAINT_SCHEMA = DATABASE()
	  AND TABLE_NAME = 'users'
	  AND CONSTRAINT_NAME = 'chk_users_role'
	  AND CONSTRAINT_TYPE = 'CHECK'
);
SET @supports_enforced_check_constraints = (
	VERSION() LIKE '%MariaDB%'
	AND (
		@mariadb_version_major > 10
		OR (
			@mariadb_version_major = 10
			AND (
				@mariadb_version_minor > 2
				OR (@mariadb_version_minor = 2 AND @mariadb_version_patch >= 1)
			)
		)
	)
);
SET @sql = IF(
	@supports_enforced_check_constraints AND @role_check_exists = 0,
	'ALTER TABLE `users` ADD CONSTRAINT `chk_users_role` CHECK (BINARY `role` IN (BINARY ''user'', BINARY ''admin''))',
	'SELECT 1'
);
PREPARE migration_statement FROM @sql;
EXECUTE migration_statement;
DEALLOCATE PREPARE migration_statement;
