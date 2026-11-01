# Slot-Exam

Telegram Mini App для записи студентов на экзамены, лабораторные работы, коллоквиумы и зачёты.

## Требования

- Docker Desktop
- Docker Compose

## Запуск PostgreSQL

1. Клонируйте репозиторий и перейдите в его папку.
2. Запустите базу данных:

   docker compose up -d db

3. Проверьте состояние контейнера:

   docker compose ps

4. Проверьте готовность PostgreSQL:

   docker compose exec db pg_isready -U postgres -d university_booking

Ожидаемый результат: accepting connections.

## Подключение к базе данных

Если приложение запущено непосредственно на компьютере, используйте:

postgresql+psycopg://postgres:postgres@localhost:5432/university_booking

Если приложение запущено внутри Docker Compose, адрес базы данных — db:5432.

## Остановка PostgreSQL

Чтобы остановить контейнер, выполните:

docker compose down

Данные сохраняются в Docker volume postgres_data.

Чтобы удалить контейнер и все сохранённые данные базы, выполните:

docker compose down -v

Внимание: эта команда удаляет данные локальной базы.

## Текущий статус

- [x] Локальный PostgreSQL через Docker Compose
- [ ] Подключение бэкенда
- [ ] Миграции Alembic
- [ ] Автоматические проверки GitHub Actions
- [ ] Деплой бэкенда
