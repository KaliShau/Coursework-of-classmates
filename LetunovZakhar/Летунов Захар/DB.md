
___
1. **Таблица `users` (Пользователи)**
    
    - `id` (SERIAL, PRIMARY KEY) - уникальный идентификатор пользователя.
    - `username` (VARCHAR(50), UNIQUE, NOT NULL) - логин пользователя.
    - `password` (VARCHAR(255), NOT NULL) - пароль.
    - `role` (VARCHAR(20), NOT NULL) - роль пользователя (админ, оператор, гость).
    
2. **Таблица `students` (Обучающиеся)**
    
    - `id` (SERIAL, PRIMARY KEY) - уникальный идентификатор обучающегося.
    - `full_name` (VARCHAR(100), NOT NULL) - полное имя обучающегося.
    - `group_name` (VARCHAR(50), NOT NULL) - название группы/класса.
    
3. **Таблица `events` (Мероприятия)**
    
    - `id` (SERIAL, PRIMARY KEY) - уникальный идентификатор мероприятия.
    - `event_name` (VARCHAR(100), NOT NULL) - название мероприятия.
    - `event_date` (DATE, NOT NULL) - дата проведения мероприятия.
    
4. **Таблица `participation` (Участие)**
    
    - `id` (SERIAL, PRIMARY KEY) - уникальный идентификатор записи об участии.
    - `student_id` (INTEGER, REFERENCES students(id), NOT NULL) - идентификатор обучающегося.
    - `event_id` (INTEGER, REFERENCES events(id), NOT NULL) - идентификатор мероприятия.
    - `participation_type` (VARCHAR(50)) - тип участия (например, "организатор", "участник").
    - `points` (INTEGER) - баллы за участие.