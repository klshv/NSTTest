# Приложение для оценки компетенций сотрудников

## Основные сущности
Система оперируют следующими сущностями:
```
Person (Сотрудник):
{
  id: long,
  name: string,
  displayName: string,
  skills: [Skill, Skill, Skill, …]
}

Skill (Навык)
{
  name: string,
  level: byte // 1-10
}
```
## API взаимодействия
GET api/v1/persons
>Возвращает массив объектов типа Person:
[Person, Person, …]

GET api/v1/persons/[id]
Где id – уникальный идентификатор сотрудника.
>Возвращает объект типа Person.

POST api/v1/persons
>В теле запроса передавать объект Person без указания Id.
Создаёт нового сотрудника в системе с указанными навыками.

PUT api/v1/persons/[id]
Где id – уникальный идентификатор сотрудника.
>В теле запроса передавать объект Person без указания Id (как в методе POST). 
Обновляет данные сотрудника согласно значениям, указанным в объекте Person в теле. Обновляет навыки сотрудника согласно указанному набору.

DELETE api/v1/persons/[id]
>Где id – уникальный идентификатор сотрудника.
Удаляет с указанным id сотрудника из системы.

## Статусы ответов:
- 200 – успешное выполнение запроса.
- 400 – неверный запрос.
- 404 – сущность не найдена в системе.
- 500 – серверная ошибка (например, при обработке данных).
