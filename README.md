
Proyecto de **Web API** con ASP.NET Core para gestionar usuarios básicos del sistema de denuncias, desarrollado siguiendo las sesiones del curso.

## Características principales
- ASP.NET Core Web API con **Controllers** (no Minimal APIs)
- Entity Framework Core + SQL Server (LocalDB)
- DTOs para entrada (`CreateUserDto`) y salida (`UserDto`)
- Validación básica en el controlador (username y email obligatorios)
- Swagger habilitado solo en entorno de Development
- CRUD completo: GET (todos y por ID), POST, PUT, DELETE
- Base de datos creada automáticamente en LocalDB al hacer el primer POST

## Endpoints disponibles
| Método | Endpoint              | Descripción                              | Body (ejemplo POST/PUT)                                      |
|--------|-----------------------|------------------------------------------|--------------------------------------------------------------|
| GET    | /api/users            | Lista todos los usuarios                 | —                                                            |
| GET    | /api/users/{id}       | Obtiene un usuario por ID                | —                                                            |
| POST   | /api/users            | Crea un nuevo usuario                    | `{ "username": "ranfy123", "email": "ranfy@example.com", "fullName": "Ranfy Alejandro" }` |
| PUT    | /api/users/{id}       | Actualiza un usuario existente           | `{ "username": "ranfy_edit", "email": "ranfy2@example.com", "fullName": "Ranfy Editado" }` |
| DELETE | /api/users/{id}       | Elimina un usuario                       | —                                                            |

Respuestas HTTP esperadas:
- 200 OK (GET exitoso)
- 201 Created (POST exitoso, con Location header)
- 204 No Content (PUT/DELETE exitoso)
- 400 Bad Request (validación fallida)
- 404 Not Found (ID no existe)

## Cómo ejecutar localmente
1. Clona el repositorio:
git clone https://github.com/Ranleisy/DenunciaUnaBestia-Api-CRUD-Municipalities-Ranfy.git
text2. Entra a la carpeta del proyecto:
cd DenunciaUnaBestia-Api-CRUD-Municipalities-Ranfy/DenunciaUnaBestia.Api
text3. Compila:
dotnet build
text4. Ejecuta:
dotnet run
text5. Abre en el navegador:
http://localhost:5133/swagger
text(El puerto puede variar; mira la consola)

La base de datos `DenunciaUnaBestiaUsers` se crea automáticamente en **LocalDB** al hacer el primer POST.

## Tecnologías utilizadas
- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server LocalDB
- Swashbuckle.AspNetCore (Swagger)
- DTOs para separación de capas

## Estructura del proyecto
DenunciaUnaBestia.Api/
├── Controllers/
│   └── UsersController.cs
├── Data/
│   └── ApplicationDbContext.cs
├── Models/
│   ├── Entities/
│   │   └── User.cs
│   └── Dtos/
│       ├── CreateUserDto.cs
│       └── UserDto.cs
├── appsettings.Development.json
├── Program.cs
└── DenunciaUnaBestia.Api.csproj
text## Notas adicionales
- Proyecto personalizado: se cambió el tema de Municipios a **Usuarios** para diferenciarlo y adaptarlo mejor al contexto de "DenounceBeasts".
- Todo alineado a las sesiones del curso (estructura de carpetas, uso de DTOs, validación básica, Swagger en Dev).

Hecho por: Ranfy  
Fecha: Febrero 2026
