# DenunciaUnaBestia - Red Social API

Proyecto de **Web API** con ASP.NET Core para gestionar una red social, desarrollado siguiendo las sesiones del curso.

## Características principales
- ASP.NET Core Web API con **Controllers** (no Minimal APIs)
- Entity Framework Core + SQL Server
- Arquitectura en capas: **Domain** e **Infrastructure**
- Repositorios con patrón Repository + interfaces
- Swagger habilitado solo en entorno de Development
- CRUD completo para todas las entidades

## Entidades
- **Usuario** — Usuarios de la red social
- **Post** — Publicaciones de los usuarios
- **Comentario** — Comentarios en publicaciones
- **Like** — Likes en publicaciones
- **Seguidor** — Relación de seguimiento entre usuarios

## Endpoints disponibles

### Usuarios
| Método | Endpoint | Descripción |
|--------|----------|-------------|
| GET | /api/usuarios | Lista todos los usuarios |
| GET | /api/usuarios/{id} | Obtiene un usuario por ID |
| GET | /api/usuarios/{id}/seguidores | Obtiene los seguidores de un usuario |
| POST | /api/usuarios | Crea un nuevo usuario |
| PUT | /api/usuarios/{id} | Actualiza un usuario |
| DELETE | /api/usuarios/{id} | Elimina un usuario |

### Posts
| Método | Endpoint | Descripción |
|--------|----------|-------------|
| GET | /api/posts | Lista todos los posts |
| GET | /api/posts/{id} | Obtiene un post por ID |
| GET | /api/posts/usuario/{usuarioId} | Posts de un usuario |
| GET | /api/posts/feed/{usuarioId} | Feed de un usuario |
| POST | /api/posts | Crea un nuevo post |
| PUT | /api/posts/{id} | Actualiza un post |
| DELETE | /api/posts/{id} | Elimina un post |

### Comentarios
| Método | Endpoint | Descripción |
|--------|----------|-------------|
| GET | /api/comentarios | Lista todos los comentarios |
| GET | /api/comentarios/{id} | Obtiene un comentario por ID |
| GET | /api/comentarios/post/{postId} | Comentarios de un post |
| POST | /api/comentarios | Crea un comentario |
| PUT | /api/comentarios/{id} | Actualiza un comentario |
| DELETE | /api/comentarios/{id} | Elimina un comentario |

### Likes
| Método | Endpoint | Descripción |
|--------|----------|-------------|
| GET | /api/likes | Lista todos los likes |
| GET | /api/likes/{id} | Obtiene un like por ID |
| GET | /api/likes/post/{postId} | Likes de un post |
| GET | /api/likes/exists/{usuarioId}/{postId} | Verifica si existe un like |
| POST | /api/likes | Crea un like |
| DELETE | /api/likes/{id} | Elimina un like |

### Seguidores
| Método | Endpoint | Descripción |
|--------|----------|-------------|
| GET | /api/seguidores | Lista todos los seguidores |
| GET | /api/seguidores/{id} | Obtiene un seguidor por ID |
| GET | /api/seguidores/siguiendo/{seguidorId}/{seguidoId} | Verifica si sigue a alguien |
| GET | /api/seguidores/seguidos/{usuarioId} | Lista los seguidos de un usuario |
| POST | /api/seguidores | Crea una relación de seguimiento |
| DELETE | /api/seguidores/{id} | Elimina una relación de seguimiento |

## Cómo ejecutar localmente
1. Clona el repositorio:
```
git clone https://github.com/Ranleisy/DenunciaUnaBestia-Api-CRUD-Municipalities-Ranfy.git
```
2. Entra a la carpeta del proyecto:
```
cd DenunciaUnaBestia-Api-CRUD-Municipalities-Ranfy/DenunciaUnaBestia.Api
```
3. Compila:
```
dotnet build
```
4. Crea la base de datos:
```
dotnet ef database update --project ..\DenunciaUnaBestia.Domain --startup-project . --context DenunciaUnaBestiaContext
```
5. Ejecuta:
```
dotnet run
```
6. Abre en el navegador:
```
http://localhost:5133/swagger
```

## Tecnologías utilizadas
- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swashbuckle.AspNetCore (Swagger)
- Patrón Repository

## Estructura del proyecto
```
DenunciaUnaBestia.Domain/
├── Core/
│   └── BaseEntity.cs
├── Entities/
│   ├── Usuario.cs
│   ├── Post.cs
│   ├── Comentario.cs
│   ├── Like.cs
│   └── Seguidor.cs
└── Repository/
    └── Infrastructure/
        ├── Context/
        │   └── DenunciaUnaBestiaContext.cs
        ├── Core/
        │   └── BaseRepository.cs
        ├── Exceptions/
        │   └── RedSocialExceptions.cs
        ├── Interfaces/
        │   ├── IBaseRepository.cs
        │   └── IRepositories.cs
        ├── Models/
        │   └── RedSocialModels.cs
        └── Repositories/
            └── Repositories.cs

DenunciaUnaBestia.Api/
├── Controllers/
│   ├── UsersController.cs
│   └── Controllers.cs
├── appsettings.json
└── Program.cs
```

## Hecho por: Alejandro
## Fecha: Marzo 2026
