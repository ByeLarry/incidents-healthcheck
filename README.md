# Сервис мониторинга состояния системы

## Описание

Данный репозиторий содержит реализацию микросервиса проверки состояния распределенной системы проекта **Incidents**.
Используется фреймворк **ASP.NET Core** на платформе **.NET 8.0**. 
Коммуникация с другими микросервисами осуществлятся с помощью **HTTP** запросов.

Для осуществления проверки состояния компонентов распределенной системы используются библиотеки пространства имен **AspNetCore.HealthChecks**.
Графический интерфейс реализован с помощью библиотеки **AspNetCore.HealthChecks.UI**.

## Установка
### Docker 
```bash
# Переход в директорию с исходниками
cd IncidentsHealthCheckSolution

# Создание и запуск docker сервисов
docker-compose -f "docker-compose.yml" -f "docker-compose.override.yml" -p "incidents-healthcheck-service" up -d
```

## Проектирование

_Диаграммы можно сохранять и редактировать в ***[draw.io](https://app.diagrams.net/)***_

- ### Компоненты микросервиса проверки состояния системы
  ![Компоненты микросервиса проверки состояния системы](https://github.com/user-attachments/assets/052d2fa2-affe-4623-9e90-381bd216a545)

## Ссылки

- #### Клиентская часть:  *https://github.com/ByeLarry/incidents-frontend*  [![incidents-frontend](https://github.com/ByeLarry/incidents-frontend/actions/workflows/incidents-frontend.yml/badge.svg)](https://github.com/ByeLarry/incidents-frontend/actions/workflows/incidents-frontend.yml)
- #### Сервис авторизации:  *https://github.com/ByeLarry/incidents-auth-service*  [![incidents-auth](https://github.com/ByeLarry/incidents-auth-service/actions/workflows/incidents-auth.yml/badge.svg)](https://github.com/ByeLarry/incidents-auth-service/actions/workflows/incidents-auth.yml)
- #### Сервис марок (инцидентов): *https://github.com/ByeLarry/indcidents-marks-service*  [![incidents-marks](https://github.com/ByeLarry/incidents-marks-service/actions/workflows/incidents-marks.yml/badge.svg)](https://github.com/ByeLarry/incidents-marks-service/actions/workflows/incidents-marks.yml)
- #### Сервис поиска *https://github.com/ByeLarry/incidents-search-service*  [![incidents-search](https://github.com/ByeLarry/incidents-search-service/actions/workflows/incidents-search.yml/badge.svg)](https://github.com/ByeLarry/incidents-search-service/actions/workflows/incidents-search.yml)
- #### Панель администратора *https://github.com/ByeLarry/incidents-admin-frontend.git*  [![incidents-admin-frontend](https://github.com/ByeLarry/incidents-admin-frontend/actions/workflows/incidents-admin-frontend.yml/badge.svg)](https://github.com/ByeLarry/incidents-admin-frontend/actions/workflows/incidents-admin-frontend.yml)
- #### API-шлюз:  *https://github.com/ByeLarry/incidents-gateway*  [![incidents-gateway](https://github.com/ByeLarry/incidents-gateway/actions/workflows/incidents-gateway.yml/badge.svg)](https://github.com/ByeLarry/incidents-gateway/actions/workflows/incidents-gateway.yml)
- #### Демонастрация функционала пользовательской части версии 0.1.0: *https://youtu.be/H0-Qg97rvBM*
- #### Демонастрация функционала пользовательской части версии 0.2.0: *https://youtu.be/T33RFvfTxNU*
- #### Демонастрация функционала панели администратора версии 0.1.0: *https://youtu.be/7LTnEMYuzUo*
