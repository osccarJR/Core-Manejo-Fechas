# 🕒 Core de Manejo de Fechas - ASP.NET Core MVC

Este proyecto implementa un Core de manejo de fechas en ASP.NET Core MVC, aplicando principios SOLID (SRP, OCP) y patrones de diseño (Singleton y Factory Method).

## 🔧 Funcionalidades principales

- Registro de acciones con fecha actual del sistema (Singleton)
- Listado de logs con formato legible o ISO (Factory Method)
- Cálculo de diferencia entre dos fechas
- Conversión de fechas a distintas zonas horarias
- Validaciones, feedback visual y estructura profesional

## 🧱 Principios y Patrones aplicados

- **SRP**: separación de responsabilidades (servicio de fechas)
- **OCP**: formatos de fecha extensibles
- **Singleton**: proveedor único de fecha del sistema
- **Factory Method**: estrategia de formateo flexible

## 🖼️ Estructura

- Controllers/
- Models/
- Data/
- Services/
- Interfaces/
- Implementations/
- Factories/
- Views/
- ViewModels/