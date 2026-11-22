# FridgeTrack

FridgeTrack es una app web que hice en ASP.NET Core MVC para llevar el control de los alimentos que tengo en el refrigerador. Me sirve para ver qué tengo, cuánto me queda y cuándo se vence cada cosa, así no se me daña nada.

Los datos se guardan en una base de datos SQLite (`fridgetrack.db`) usando Entity Framework Core. La primera vez que se corre la app se crea sola con 6 alimentos de ejemplo.

## Cómo ejecutarla

Necesitas tener instalado .NET 9 o superior.

```bash
cd FridgeTrack
dotnet run
```

Después abres en el navegador http://localhost:5230

## Qué se puede hacer

- **Ver la lista (Select):** la página principal muestra todos los alimentos ordenados por fecha de vencimiento, así veo primero lo que se vence antes.
- **Ver el detalle (Select):** con el enlace "Ver" se abre la información de un solo alimento.
- **Agregar (Insert):** con "Agregar alimento" lleno un formulario con nombre, categoría, cantidad y fecha de vencimiento.
- **Editar (Update):** con "Editar" cambio los datos de un alimento, por ejemplo cuando ya me comí una parte.
- **Eliminar (Delete):** con "Eliminar" me pide confirmar antes de borrarlo.

Si dejo el nombre o la categoría vacíos, o pongo una cantidad de 0, el formulario no guarda y me muestra el error.

## Qué hace cada parte

- `Models/Alimento.cs`: la clase del alimento con sus campos (Id, Nombre, Categoria, Cantidad, FechaVencimiento).
- `Models/FridgeContext.cs`: el contexto de EF Core que conecta con SQLite y tiene los alimentos de ejemplo.
- `Controllers/AlimentosController.cs`: tiene las acciones de listar, ver detalle, crear, editar y eliminar.
- `Views/Alimentos/`: las vistas Razor de cada pantalla (Index, Detalle, Crear, Editar y Eliminar).
- `Program.cs`: configura MVC, la conexión a la base de datos y crea la base si no existe.

## Pruebas

En el proyecto `FridgeTrack.Tests` hice 4 pruebas con MSTest. Usan una base de datos en memoria, así no se toca la base de datos real:

- `Index_MuestraLosAlimentosDeLaBaseDeDatos`: revisa que la lista traiga los 6 alimentos (Select).
- `Crear_AgregaUnAlimentoNuevo`: agrega un yogurt y revisa que ahora haya 7 (Insert).
- `Editar_CambiaLosDatosDelAlimento`: cambia el nombre y la cantidad de la leche y revisa que se guardó (Update).
- `ConfirmarEliminar_BorraElAlimento`: elimina los huevos y revisa que ya no estén (Delete).

Para correrlas, desde la carpeta `FridgeTrackSolucion`:

```bash
dotnet test
```
