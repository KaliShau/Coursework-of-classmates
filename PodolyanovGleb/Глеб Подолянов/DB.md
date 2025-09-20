
___
1. **Users (Пользователи):** 
    
	- `ID` INT PRIMARY KEY AUTO_INCREMENT (Уникальный идентификатор )
    - `created_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP (Дата и время создания записи)
    
    - `login` VARCHAR(50) NOT NULL UNIQUE (Логин пользователя)
    - `password` VARCHAR(255) NOT NULL (Хэшированный пароль пользователя)
    
    - `first_name` VARCHAR(50) (Имя пользователя)
    - `last_name` VARCHAR(50) (Фамилия пользователя)
    - `email` VARCHAR(100) UNIQUE (Электронная почта пользователя)
    - `phone_number` VARCHAR(20) (Номер телефона пользователя)
    
     - `role_id` INT NOT NULL (Внешний ключ к таблице Roles)
    
2. **Roles (Роли):**
    
    - `ID` INT PRIMARY KEY AUTO_INCREMENT (Уникальный идентификатор )
    - `created_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP (Дата и время создания записи)
    
    - `name` VARCHAR(50) NOT NULL UNIQUE (Название роли: Admin, ASU_staff, Сlient)
    - `description` TEXT (Описание роли)
    
    
3. **Statements (Заявление):**
    - `ID` INT PRIMARY KEY AUTO_INCREMENT (Уникальный идентификатор )
    - `created_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP (Дата и время создания записи)
	
	- FIO TEXT NOT NULL (ФИО заявителя)
	- address TEXT NOT NULL (Адресс где должна проводится работа)
	- type_work TEXT NOT NULL   (Тип работы)
	- types_work_id INT NOT NULL (Внешний ключ к таблице TypesWork)
	
4. **TypesWork (Роли):**
    
    - `ID` INT PRIMARY KEY AUTO_INCREMENT (Уникальный идентификатор )
    - `created_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP (Дата и время создания записи)
    
    - `name` VARCHAR(50) NOT NULL UNIQUE (Типы работ)
    - `description` TEXT (Описание работ)