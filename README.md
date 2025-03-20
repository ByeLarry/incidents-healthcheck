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
  ![Компоненты микросервиса проверки состояния системы](https://github.com/user-attachments/assets/d379d926-14ee-4fa4-be75-ac2b6dbb5ba3)

## Прототипы пользовательского интерфейса

- ### Прототип главной страницы
  ![Сервис мониторинга состояния системы](https://github.com/user-attachments/assets/d2dcea99-70cb-42e5-a70e-032118267185)

## Ссылки

### Репозитории
- #### Клиентская часть:  *https://github.com/ByeLarry/incidents-frontend*  [![incidents-frontend](https://github.com/ByeLarry/incidents-frontend/actions/workflows/incidents-frontend.yml/badge.svg)](https://github.com/ByeLarry/incidents-frontend/actions/workflows/incidents-frontend.yml)
- #### API-шлюз:  *https://github.com/ByeLarry/incidents-gateway*  [![incidents-gateway](https://github.com/ByeLarry/incidents-gateway/actions/workflows/incidents-gateway.yml/badge.svg)](https://github.com/ByeLarry/incidents-gateway/actions/workflows/incidents-gateway.yml)
- #### Сервис авторизации:  *https://github.com/ByeLarry/incidents-auth-service*  [![incidents-auth](https://github.com/ByeLarry/incidents-auth-service/actions/workflows/incidents-auth.yml/badge.svg)](https://github.com/ByeLarry/incidents-auth-service/actions/workflows/incidents-auth.yml)
- #### Сервис марок (инцидентов): *https://github.com/ByeLarry/indcidents-marks-service*  [![incidents-marks](https://github.com/ByeLarry/incidents-marks-service/actions/workflows/incidents-marks.yml/badge.svg)](https://github.com/ByeLarry/incidents-marks-service/actions/workflows/incidents-marks.yml)
- #### Сервис поиска *https://github.com/ByeLarry/incidents-search-service*  [![incidents-search](https://github.com/ByeLarry/incidents-search-service/actions/workflows/incidents-search.yml/badge.svg)](https://github.com/ByeLarry/incidents-search-service/actions/workflows/incidents-search.yml)
- #### Панель администратора *https://github.com/ByeLarry/incidents-admin-frontend.git*  [![incidents-admin-frontend](https://github.com/ByeLarry/incidents-admin-frontend/actions/workflows/incidents-admin-frontend.yml/badge.svg)](https://github.com/ByeLarry/incidents-admin-frontend/actions/workflows/incidents-admin-frontend.yml)
- #### Сервис мониторинга состояния системы: *https://github.com/ByeLarry/incidents-healthcheck*  [![incidents-healthcheck](https://github.com/ByeLarry/incidents-healthcheck/actions/workflows/incidents-healthcheck.yml/badge.svg)](https://github.com/ByeLarry/incidents-healthcheck/actions/workflows/incidents-healthcheck.yml)
- #### Telegram бот для уведомления о состоянии системы *https://github.com/ByeLarry/incidents-healthcheck-bot*
- #### Сквозные (end-to-end) тесты *https://github.com/ByeLarry/incidents-playwright*

### Демонстрация функционала
- #### Демонастрация функционала пользовательской части версии 0.1.0: *https://youtu.be/H0-Qg97rvBM*
- #### Демонастрация функционала пользовательской части версии 0.2.0: *https://youtu.be/T33RFvfTxNU*
- #### Демонастрация функционала панели администратора версии 0.1.0: *https://youtu.be/7LTnEMYuzUo*
