# Reserve-copy
A backup tool for changes to folders with files from a connected database.

Инструмент резервного копирования изменений папок с файлами.
- индексировать папку, т.е записать ключевые атрибуты файлов и папок в БД.
- подсчет кеш суммы разных способов и определить оптимальный
- определить необходимость синхронизации в фоне или по нажатию на кнопку. 
- синхронизация:
- создание патчей и сохранить в БД
- полное копирование и сохранить в БД


папка 1  —> папка 1a, папка 1b, папка 1c
папка 2 —> папка 2a


- [X] Md5
- [X] Copy Delete - С удалением файла и его записью
- [X] Copy Overwriting - Просто перезапись
- [ ] Поток сохранение файлов
- [ ] Создание невидимого файла
- [ ] Проверка этого файла
- [ ] Обращение к бирже и запуск потоков сохранения
- [ ] Биржа
- [ ] Метод чекер
- [ ] Класс обращение к бд
- [ ] БД
- [ ] Главный Класс взаимодействия

- [ ] Интерфейс
