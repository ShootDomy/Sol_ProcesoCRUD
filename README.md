# 📇 CRUD de Contactos – C# + PostgreSQL

Este es un proyecto de ejemplo que implementa un sistema CRUD (Crear, Leer, Actualizar, Eliminar) de contactos utilizando C# (.NET), ademas de implementar una zona de reportes aplicando el filtro de la busqueda y PostgreSQL como base de datos.

## 🛠️ Tecnologías utilizadas

- C# (.NET Framework)
- PostgreSQL
- Npgsql (driver para conectar .NET con PostgreSQL)
- Visual Studio 2022

## 📦 Funcionalidades
- 📥 Crear nuevos contactos
- 🔍 Listar todos los contactos
- ✏️ Editar información de contacto
- ❌ Eliminar contactos
- 🧪 Validación básica de datos
- 🗃️ Generación automática de UUIDs

## 🧾 Estructura de la base de datos

⚠️ **Nota:** Asegúrate de tener habilitada la extensión `pgcrypto` en PostgreSQL para poder usar `gen_random_uuid()`.

```sql
CREATE EXTENSION IF NOT EXISTS "pgcrypto";
```

- Tabla cargos
```sql
CREATE TABLE IF NOT EXISTS public.cargos
(
    car_uuid uuid NOT NULL DEFAULT gen_random_uuid(),
    car_descripcion character varying COLLATE pg_catalog."default",
    car_activo boolean DEFAULT true,
    created_at timestamp with time zone NOT NULL DEFAULT now(),
    updated_at time with time zone,
    deleted_at time with time zone,
    CONSTRAINT cargod_pkey PRIMARY KEY (car_uuid)
)
```
- Tabla contactos
```sql
CREATE TABLE IF NOT EXISTS public.contactos
(
    con_uuid uuid NOT NULL DEFAULT gen_random_uuid(),
    con_nombre character varying COLLATE pg_catalog."default",
    con_telefono character varying COLLATE pg_catalog."default",
    con_correo character varying COLLATE pg_catalog."default",
    con_fecha_nac timestamp with time zone,
    car_uuid uuid,
    con_activo boolean DEFAULT true,
    created_at timestamp with time zone DEFAULT now(),
    updated_at timestamp with time zone,
    deleted_at timestamp with time zone,
    CONSTRAINT contactos_pkey PRIMARY KEY (con_uuid),
    CONSTRAINT contactos_car_uuid_fkey FOREIGN KEY (car_uuid)
        REFERENCES public.cargos (car_uuid) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)
```
- Función para tabla, filtro de busqueda y el reporte
```sql
CREATE OR REPLACE FUNCTION public.func_listado_contacto(
	ctexto character varying)
    RETURNS TABLE(codigo uuid, nombre character varying, telefono character varying, correo character varying, fecha_nac timestamp with time zone, cargo character varying) 
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
BEGIN
	RETURN QUERY
		SELECT con.con_uuid, con.con_nombre, con.con_telefono, con.con_correo, 
			con.con_fecha_nac, car.car_descripcion
		FROM contactos con
		INNER JOIN cargos car ON car.car_uuid = con.car_uuid
		WHERE con.con_activo IS TRUE AND con.deleted_at ISNULL
			AND UPPER(con.con_nombre) LIKE UPPER('%'||cTexto||'%');
END;
$BODY$;

ALTER FUNCTION public.func_listado_contacto(character varying)
    OWNER TO postgres;
```
## ▶️ Cómo ejecutar el proyecto

1. Clona este repositorio:
```bash
git clone https://github.com/ShootDomy/Sol_ProcesoCRUD.git
```

3. Abre el archivo .sln en Visual Studio 2022.
4. Configura la cadena de conexión a PostgreSQL en el archivo de configuración (app.config o appsettings.json).
5. Ejecuta el proyecto desde Visual Studio.

## 📸 Capturas de pantalla
<img width="1426" height="677" alt="Image" src="https://github.com/user-attachments/assets/67a7cfb9-56d0-4a98-9eb4-023fda5ee1c3" />

## 👤 Autor
Este proyecto fue creado por **Domenica Vintimilla**.

- **Correo**: [canizaresdomenica4@gmail.com](mailto:canizaresdomenica4@gmail.com)
- **GitHub**: [https://github.com/ShootDomy](https://github.com/ShootDomy)
- **LinkedIn**: [https://www.linkedin.com/in/domenica-vintimilla-24a735245/](https://www.linkedin.com/in/domenica-vintimilla-24a735245/)



