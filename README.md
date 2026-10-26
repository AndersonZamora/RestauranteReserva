# RestauranteReserva — reservas de mesas de un restaurante

Aplicación web para **gestionar las reservas de un restaurante**: mesas, platos y categorías del menú, personal y reservas, con inicio de sesión. Lo construí para practicar un enfoque de **calidad de punta a punta**: pruebas unitarias, pruebas de interfaz (Selenium IDE) y pruebas de carga (JMeter).

## Qué hace

- **Reservas**: registrar y consultar reservas con nombre del cliente, celular, fecha y mesa asignada.
- **Mesas**: administración de las mesas del salón.
- **Menú**: platos y categorías de plato.
- **Personal y usuarios**: alta de personal y acceso con cookie.

## Stack

| Capa | Tecnología |
|---|---|
| Web | ASP.NET Core 5 MVC |
| Datos | Entity Framework Core 5 (migraciones) + SQL Server |
| Autenticación | Cookies (`CookieAuthentication`) |
| Pruebas unitarias | NUnit 3 + Moq |
| Pruebas de interfaz | Selenium IDE (casos `.side`) |
| Pruebas de carga | Apache JMeter |

## Estructura

```
Reservas/              aplicación web
  Controllers/         Auth, Categorias, Mesas, Platos, Reserva, Usuarios
  Service/ Interface/  servicios y contratos por dominio
  Models/ Migrations/  entidades y migraciones de EF Core
PruebasUnitarias/      66 pruebas NUnit con Moq (servicios y controladores)
PruebasSelenium/       casos de Selenium IDE: login, mesas, personal y reservas
PruebasJmeter/         plan de carga con 174 peticiones HTTP
```

## Pruebas

- **Unitarias**: cada controlador y servicio se prueba con dependencias y contexto de datos simulados con Moq.
- **Selenium IDE**: los casos de `PruebasSelenium/*.side` se importan en la extensión de Selenium IDE y se ejecutan contra la aplicación en marcha.
- **JMeter**: `PruebasJmeter/TestReservasProject.jmx` define un grupo de hilos que recorre los flujos principales; ábrelo en JMeter y ajusta host y puerto.

## Cómo ejecutarlo

Requisitos: .NET 5 SDK y SQL Server (o LocalDB).

1. Ajusta la cadena `DevConnection` en `Reservas/appsettings.json`.
2. `dotnet ef database update --project Reservas` para crear la base.
3. `dotnet run --project Reservas`.
4. `dotnet test` para las pruebas unitarias.

## Nota

Proyecto de aprendizaje de 2021. .NET 5 ya no tiene soporte; para retomarlo conviene migrar a una versión LTS actual.
