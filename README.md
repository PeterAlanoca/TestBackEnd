# PRUEBA TÉCNICA

Construir una solución basada en Microservicios para la gestión de productos de un almacén y su venta:
- El modelado de las entidades se deja a criterio del postulante
- Para la persistencia de datos está permitido el uso de una estructura de datos o una base de datos
en cualquier motor.
- Se debe crear un micro servicio para la gestión de productos que debe incluir el manejo de un
inventario, se debe poder comunicar el estado del inventario de los productos a cualquier otro
micro servicio. (CRUD de Productos)
- Se debe crear un micro servicio para realizar ventas en función a cantidad y precio de los productos,
el mismo debe ser capaz de recepcionar los eventos/mensajes de Producto.
- La venta al crearse tendrá por estado PENDIENTE, habilitar un endpoint para cambiar el estado de
la venta a ENTREGADO.
- Se debe aplicar un recargo por IVA que por el momento será del 13%## Installation 

Instalación

```bash
Restaurar el archivo backup STORE.bak

Cambiar el nombre del servidor de la cadena de conexión del archivo appsettings.json de los siguientes proyectos:
- Store.Sale.Service
- Store.CRUD.Service

"ConnectionStrings": {
    "DefaultConnection": "Server=NOMBRE_SERVIDOR;Database=STORE;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
```
## Documentación

Los dos microservicios tienen  implementado Swagger, adicionalmente se describe los endpoints en la parte inferior. 
## Store CRUD Service

#### Get all Products

```http
  GET /api/v1/Products/all
```
#### Get Product

```http
  GET /api/v1/Products/{id}
```
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Requerido**. Id de producto |
#### Register Producto

```http
  POST /api/v1/Products
```
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `name`      | `string` | **Requerido** Nombre del producto |
| `code`      | `string` |  **Requerido** Código del producto |
| `quantity`      | `int` |  **Requerido** Cantidad disponible |
| `unit_cost`      | `decimal` |  **Requerido** Precio del producto |
#### Update Producto
```http
  PATCH /api/v1/Products
```
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Requerido**. Id de producto |
| `name`      | `string` |  **Requerido**. Nombre del producto |
| `code`      | `string` |  **Requerido**.Código del producto |
| `quantity`      | `int` |  **Requerido**.Cantidad disponible |
| `unit_cost`      | `decimal` |  **Requerido**.Precio del producto |
#### Delete Product

```http
  DELETE /api/v1/Products/{id}
```
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Requerido**. Id de producto |
## Store Sales Service

#### Booking

```http
  POST /api/v1/Sales
```
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `product_id `      | `int` | **Requerido**. Id de producto |
| `quantity `      | `int` | **Requerido**. Cantidad de productos que se quiere reservar |

#### Delivery

```http
  PATCH /api/v1/Sales
```
| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `sale_id `      | `int` | **Requerido**. Id  de reserva o venta |
## Authors

- [@PeterAlanoca](https://github.com/PeterAlanoca)
