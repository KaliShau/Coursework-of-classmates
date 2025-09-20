
___
1. Таблица `Users`
		
	- `user_id` (SERIAL PRIMARY KEY) — уникальный идентификатор пользователя.
	- `username` (VARCHAR(50) NOT NULL UNIQUE) — логин пользователя.
	- `password` (VARCHAR(255) NOT NULL) — пароль.
	- `role` (VARCHAR(20) NOT NULL) — роль пользователя (Admin, Operator, Guest).
	
2. Таблица `Materials`
		
	- `material_id` (SERIAL PRIMARY KEY) — уникальный идентификатор материала.
	- `name` (VARCHAR(100) NOT NULL) — наименование материала.
	- `quantity` (INT NOT NULL) — количество материала.
	- `unit` (VARCHAR(20) NOT NULL) — единица измерения (шт, кг, литр и т.д.).
	- `supplier_id` (INT REFERENCES Suppliers(supplier_id)) — идентификатор поставщика.
	
3. Таблица `Requests`
		
	- `request_id` (SERIAL PRIMARY KEY) — уникальный идентификатор заявки.
	- `material_id` (INT REFERENCES Materials(material_id)) — идентификатор материала.
	- `quantity` (INT NOT NULL) — количество запрашиваемого материала.
	- `status` (VARCHAR(20) NOT NULL) — статус заявки (новая, в обработке, выполнена).
	- `created_at` (TIMESTAMP DEFAULT CURRENT_TIMESTAMP) — дата создания заявки.
	
4. Таблица `Suppliers`
		
	- `supplier_id` (SERIAL PRIMARY KEY) — уникальный идентификатор поставщика.
	- `name` (VARCHAR(100) NOT NULL) — наименование поставщика.
	- `contact_person` (VARCHAR(100)) — контактное лицо.
	- `phone` (VARCHAR(20)) — телефон поставщика.
	- `email` (VARCHAR(100)) — электронная почта поставщика.