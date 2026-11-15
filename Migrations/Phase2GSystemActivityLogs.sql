CREATE TABLE IF NOT EXISTS admin_activity_logs (
	id INT AUTO_INCREMENT PRIMARY KEY,
	admin_user_id INT NOT NULL,
	action_type VARCHAR(50) NOT NULL,
	target_user_id INT NULL,
	description VARCHAR(255) NOT NULL,
	created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	INDEX idx_admin_activity_logs_admin_user_id (admin_user_id),
	INDEX idx_admin_activity_logs_target_user_id (target_user_id),
	INDEX idx_admin_activity_logs_created_at (created_at),
	CONSTRAINT fk_admin_activity_logs_admin_user
		FOREIGN KEY (admin_user_id) REFERENCES users(id),
	CONSTRAINT fk_admin_activity_logs_target_user
		FOREIGN KEY (target_user_id) REFERENCES users(id)
) ENGINE=InnoDB;
