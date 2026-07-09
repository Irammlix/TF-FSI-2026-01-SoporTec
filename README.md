<div align="center">

# SoporTec

## Sistema de Gestión de Soporte Técnico Interno

![C#](https://img.shields.io/badge/C%23-512BD4?logo=csharp)
![.NET](https://img.shields.io/badge/.NET-512BD4?logo=dotnet)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?logo=microsoftsqlserver)
![Entity Framework 6](https://img.shields.io/badge/EF6-68217A)
![Git](https://img.shields.io/badge/Git-F05032?logo=git)

**Universidad Peruana de Ciencias Aplicadas (UPC)**

**Facultad de Ingeniería**

**Fundamentos de Sistemas de Información**

**Trabajo Final**

**Profesor: William Eduardo Bravo García**

<br>

### Integrantes

| Integrante | Código |
|------------|---------|
| Cordero García Máximo Julio Enrique | u20241c678 |
| Hallasi Yucra Maria Fernanda | u202415759 |
| Porras Aliano Juan David | u20211b144 |
| Rojas Quispe Aida Nicole | u20241e313 |
| Vasquez Quispe Milene | u202419061 |

</div>

---

## Descripción

## Descripción del problema

En muchas instituciones educativas, las incidencias relacionadas con equipos, redes, software o credenciales se gestionan mediante correos electrónicos, llamadas o mensajes informales. Esto dificulta el seguimiento de las solicitudes, incrementa los tiempos de respuesta y genera una distribución ineficiente de la carga de trabajo entre los técnicos.

La ausencia de un sistema centralizado también limita la trazabilidad de cada incidencia, dificultando conocer su estado, prioridad, historial de atención y responsable asignado. Como consecuencia, los administradores carecen de información confiable para supervisar el servicio y tomar decisiones basadas en datos.

**SoporTec** surge como una solución para centralizar la gestión del soporte técnico interno mediante un sistema de tickets que permite registrar, asignar, atender y monitorear incidencias de manera organizada, mejorando la eficiencia del proceso y la comunicación entre solicitantes, técnicos y administradores.

## Justificación

Este proyecto fue desarrollado como trabajo final del curso **Fundamentos de Sistemas de Información** de la **Universidad Peruana de Ciencias Aplicadas (UPC)**.

SoporTec aplica los conceptos estudiados durante el curso para resolver una problemática real mediante una solución informática basada en una arquitectura por capas, una base de datos relacional y una interfaz de escritorio desarrollada en C#. Además de optimizar la gestión de incidencias, el sistema incorpora reportes que facilitan el análisis de información y apoyan la toma de decisiones.

## Objetivos

### Objetivo general

Desarrollar un sistema de gestión de soporte técnico interno que permita registrar, asignar, gestionar y dar seguimiento a las incidencias reportadas por los usuarios, optimizando la administración de tickets y facilitando la toma de decisiones mediante reportes e indicadores.

### Objetivos específicos

* Centralizar el registro y seguimiento de incidencias en una única plataforma.
* Facilitar la asignación de tickets a técnicos según la prioridad y las necesidades del servicio.
* Permitir que los técnicos actualicen el estado de las incidencias y registren el progreso de su atención.
* Proporcionar al administrador reportes gráficos e indicadores que apoyen el monitoreo del servicio y la toma de decisiones.
* Implementar una arquitectura por capas que favorezca la organización, mantenibilidad y escalabilidad del sistema.

## Roles del sistema

### Solicitante

El solicitante es el usuario que registra incidencias y realiza el seguimiento de sus solicitudes de soporte.

**Funciones principales:**

* Registrar nuevos tickets de soporte.
* Consultar el estado de sus incidencias.
* Visualizar el detalle de cada ticket.
* Exportar la información del ticket en PDF o Excel.

| Nueva Solicitud | Mis Tickets |
|-----------------|-------------|
| <img width="1902" height="1003" alt="Captura de pantalla 2026-07-09 001924" src="https://github.com/user-attachments/assets/031226d7-d190-4dfd-88b3-392909474fe8" /> | <img width="1907" height="1001" alt="Captura de pantalla 2026-07-09 002205" src="https://github.com/user-attachments/assets/0820308c-5102-48f6-9310-f5d02df02075" />|

---

###  Técnico

El técnico es responsable de atender las incidencias asignadas, actualizar su progreso y registrar comentarios sobre la atención realizada.

**Funciones principales:**

* Consultar los tickets asignados.
* Filtrar tickets por estado y prioridad.
* Actualizar el estado de atención.
* Registrar comentarios técnicos.
* Exportar listados y detalles de tickets.

| Tickets Asignados | Detalle de Ticket |
|-----------------|-------------|
| <img width="1905" height="1007" alt="Captura de pantalla 2026-07-09 002342" src="https://github.com/user-attachments/assets/6d5e9fff-f254-42eb-b113-77c8b16368b6" />| <img width="1907" height="1002" alt="image" src="https://github.com/user-attachments/assets/f599af4b-7227-444e-ac65-7c430d9c6e64" />|

---

###  Administrador

El administrador supervisa el funcionamiento del sistema, asigna incidencias al personal técnico y analiza el desempeño mediante reportes.

**Funciones principales:**

* Gestionar todos los tickets registrados.
* Asignar técnicos y prioridades.
* Administrar el personal técnico.
* Consultar reportes e indicadores.
* Exportar reportes y listados.

| Tickets Registrados | Asignar un Ticket |
|-----------------|-------------|
| <img width="1902" height="996" alt="image" src="https://github.com/user-attachments/assets/d1bdc9b6-1ce5-4ec9-94d6-0430c147ddfe" /> | <img width="1906" height="1002" alt="image" src="https://github.com/user-attachments/assets/af517f04-f36c-472f-b8d9-e4ae704f0802" />|

## Funcionalidades principales

SoporTec integra diferentes módulos que permiten gestionar el ciclo completo de atención de incidencias técnicas.

#### Gestión de Tickets

* Registro de nuevas solicitudes de soporte.
* Consulta y seguimiento del estado de los tickets.
* Visualización del detalle de cada incidencia.
* Filtrado y búsqueda de tickets.

#### Gestión de Técnicos

* Asignación de tickets a técnicos.
* Administración de prioridades.
* Consulta de técnicos registrados.
* Visualización de la carga de trabajo por técnico.

#### Reportes e Indicadores

El módulo de reportes proporciona información visual sobre el estado del servicio de soporte técnico, permitiendo al administrador monitorear el rendimiento del equipo, identificar tendencias y tomar decisiones basadas en datos.

* Reportes destacados

| Distribución por estado | Tickets por prioridad |
|-------------------------|-----------------------|
| <img width="1335" height="675" alt="image" src="https://github.com/user-attachments/assets/c9a224a8-795b-4d95-b321-9cd8d9a26e64" /> | <img width="1338" height="681" alt="image" src="https://github.com/user-attachments/assets/1c4135f7-c471-45bb-99ae-db42b35a96b2" />|

#### Exportación de Información

* Exportación de tickets en PDF y Excel.
* Exportación de reportes.
* Descarga de listados para análisis y seguimiento.

#### Seguridad

* Autenticación por roles.
* Acceso restringido según permisos.
* Gestión independiente para Solicitante, Técnico y Administrador.

##  Arquitectura del sistema

SoporTec fue desarrollado siguiendo una **arquitectura por capas**, separando la interfaz de usuario, la lógica de negocio y el acceso a los datos. Esta organización facilita el mantenimiento del código, mejora la escalabilidad del sistema y permite que cada capa tenga una responsabilidad específica.

La aplicación está compuesta por los siguientes componentes:

* **Capa de Presentación:** Desarrollada con **C# Windows Forms**, proporciona la interfaz gráfica para los roles de Solicitante, Técnico y Administrador, gestionando la interacción con el usuario.

* **Capa de Negocio:** Implementa las reglas de negocio y coordina los procesos del sistema, como el registro de tickets, la asignación de técnicos, la actualización de estados y la generación de reportes.

* **Capa de Datos:** Gestiona el acceso a la base de datos mediante **Entity Framework 6**, realizando las operaciones de consulta, inserción, actualización y eliminación de la información.

* **Base de Datos:** Implementada en **SQL Server**, almacena la información de usuarios, técnicos, tickets, especialidades, sedes, pabellones y demás entidades necesarias para el funcionamiento del sistema.

### **Diagrama de arquitectura**

<p align="center">
  <img width="476" height="427" alt="Arquitectura de SoporTec" src="https://github.com/user-attachments/assets/0fad410f-2b70-418a-a3e4-e5d572cf947f" >
</p>

## Modelo de Base de Datos

La persistencia de la información en **SoporTec** se implementó mediante **SQL Server**, utilizando un modelo de base de datos relacional diseñado para garantizar la integridad y consistencia de los datos.

El esquema organiza la información necesaria para la gestión del sistema, estableciendo relaciones entre usuarios, técnicos, tickets, sedes, pabellones, especialidades y demás entidades involucradas en el proceso de atención de incidencias.

<p align="center">
  <img width="1031" height="787" alt="Modelo de Base de Datos" src="https://github.com/user-attachments/assets/57571ac7-13a8-46d4-b769-2d015cd86299" >
  <br>
  <em> Modelo entidad-relación de la base de datos de SoporTec.</em>
</p>

### Tablas principales

* **Ticket:** Almacena la información de cada incidencia registrada, incluyendo su estado, prioridad, fechas, solicitante y técnico asignado.
* **Usuario:** Gestiona la información de autenticación y los datos generales de los usuarios del sistema.
* **Técnico:** Contiene la información del personal encargado de atender las incidencias, incluyendo su especialidad y sede.
* **Especialidad:** Clasifica las áreas de conocimiento de los técnicos para facilitar la asignación de solicitudes.
* **Sede y Pabellón:** Permiten identificar la ubicación física donde se registra cada incidencia.
* **Tipo de Solicitud y Estado del Ticket:** Definen la clasificación y el ciclo de vida de las incidencias dentro del sistema.

## Tecnologías utilizadas

| Tecnología                         | Descripción                                                                                       |
| ---------------------------------- | ------------------------------------------------------------------------------------------------- |
| **C#**                             | Lenguaje principal utilizado para el desarrollo de la aplicación.                                 |
| **Windows Forms (.NET Framework)** | Framework utilizado para la construcción de la interfaz gráfica de usuario.                       |
| **Entity Framework 6**             | ORM empleado para la comunicación entre la aplicación y la base de datos.                         |
| **SQL Server**                     | Sistema de gestión de bases de datos relacional.                                                  |
| **Git & GitHub**                   | Control de versiones y gestión colaborativa del proyecto.                                         |
| **Visual Studio 2022**             | Entorno de desarrollo integrado (IDE) utilizado para el desarrollo y depuración de la aplicación. |

## Instalación

### Requisitos

Antes de ejecutar el proyecto, asegúrate de contar con los siguientes componentes instalados:

* Visual Studio 2022
* .NET Framework 4.8
* SQL Server
* SQL Server Management Studio (SSMS)

### Pasos para ejecutar el proyecto

1. Clonar el repositorio:

```bash
git clone https://github.com/Irammlix/TF-FSI-2026-01-SoporTec.git
```

2. Abrir la solución (`.sln`) en Visual Studio 2022.

3. Restaurar los paquetes NuGet del proyecto.

4. Crear la base de datos ejecutando el script SQL incluido en el repositorio.

5. Actualizar la cadena de conexión (`ConnectionString`) según la configuración local de SQL Server.

6. Establecer **CapaPresentacion** como proyecto de inicio.

7. Compilar y ejecutar la solución.

