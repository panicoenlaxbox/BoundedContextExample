# BoundedContextExample

disclaimer DDD
    pero este patrón es útil

    en vez de tener un sólo módelo que sea nuestra aplicación entera, tenemos varios
    cada uno delimitado y que aplica a un área
    particular de funcionalidad. Esto ayuda a saber que tiene ser consistente (el área) y que puede ser desarrollado independientemente

    Típico, un contexto con un chorrón de DbSet exponiendo todas las entidades

    Si queremos protegernos de que alguien meta un Customer en mitad de un Return (que no debería), no podemos hacerlo a través de DbContext, sino a través de un repo (aunque pongamos IDbSet y sólo get nadie puede prevenri llamar al método Add, sólo el repo)

    Un Bounded Context puede proyectar tipos personalizados de una entidad con sólo la información necesaria (mejora de recursos y además no haces preguntas ni estás tentando a hacer cosas con campos que no te interesan... y no tienes que hacer siempre la misma proyección), además en esas proyecciones podemos crear campos virtuales que sólo tienen sentido en esa proyección - entidad con representación diferente en función del contexto (bounded context)

        Mejor limitar la persistencia por alcance (o querying por alcance), porque al final nos traeremos igual todo... entidades sin propierdades de navegación donde proceda... y quitar Customer no significa quitar la FK, podemos dejar CustomerId pero no Customer

    Para pasar objetos entre contextos (y no siendo el mismo objeto), pasamos Id y vuelve a cargar el contexto lo que proceda ya con su entidad pero apuntando al Id correcto. Si es el mismo objeto, pues nada, muy fácil, se pasa y listo (se hace un Attach y listo)
Qué es un bounded context
Compartir entidades entre instancias
Compartir mappings entre instancias
Forzar code first a una base de datos común
    Que no descubra bd por nombre de contexto, sino crearía varias bds, queremos todos los contextos apuntando a la misma bd
        Opción meter connectionString por cada contexto... no mola, aunque funciona, otra es... el truco del almendruco


  <connectionStrings>
    <add name="ApplicationContext" connectionString="Data Source=(LocalDB)\MSSQLocalDB;Initial Catalog=ApplicationContext;Integrated Security=SSPI;MultipleActiveResultSets=True;Application Name=ApplicationContext" providerName="System.Data.SqlClient"/>
  </connectionStrings>

  //var assembly = Assembly.GetAssembly(typeof(CustomerMap));
            //var maps = assembly.GetTypes().Where(IsApplicationDatabaseInitializationMap);
            //maps.ToList().ForEach(m => modelBuilder.Configurations.Add((dynamic)Activator.CreateInstance(m)));


                    private static bool IsApplicationDatabaseInitializationMap(Type t)
        {
            return t.BaseType != null
                && t.BaseType.IsGenericType
                && t.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>)
                && t.Namespace != null
                && t.Namespace.StartsWith("DataLayer.Mappings.ApplicationDatabaseInitialization");
        }


SELECT * FROM Customers
SELECT * FROM Orders
SELECT * FROM OrderLines
SELECT * FROM Products
SELECT * FROM Invoices


SELECT TOP (1) 
    [c].[Id] AS [Id], 
    [c].[CustomerId] AS [CustomerId], 
    [c].[Amount] AS [Amount], 
    [c].[Remarks] AS [Remarks]
    FROM [dbo].[Invoices] AS [c]

SELECT TOP (1) 
    [c].[Id] AS [Id], 
    [c].[CustomerId] AS [CustomerId], 
    [c].[Amount] AS [Amount]
    FROM [dbo].[Invoices] AS [c]

exec sp_executesql N'SELECT 
    [Extent1].[Id] AS [Id], 
    [Extent1].[Name] AS [Name]
    FROM [dbo].[Customers] AS [Extent1]
    WHERE [Extent1].[Id] = @EntityKeyValue1',N'@EntityKeyValue1 int',@EntityKeyValue1=1




Domain vs domain model (problema vs modelo que implementa una solución al problema)
Subdomain vs bounded context (segmento del problema vs segmento de la solución)
Al comienzo se plantea el modelo de dominio como un modelo indivisible y se intenta construir el lenguaje ubicuo, pero a medida que adquirimos conocimiento del negocio (vamos procesando requerimientos), vemos que o bien el mismo término tiene significados distintos cuando es usado por gente distinto o bien diferentes términos son utilizados para nombrar a la misma cosa. Esto puede ser un tufo de que nuestro indivisible modelo de dominio realmente está compuesto por subdominios. 
Un bounded context es un área de la aplicación que requiere su propio lenguaje ubicuo y su propia arquitectura. Un bounded context puede tener relaciones con otros bounded context. Cuando tenemos bounded context es importante definir bien sus límites (boundaries) y sus relaciones (relationships).
Hablando de boundaries, el problema está principalmente en descubrir las áreas/entidades de solapamiento entre bounded contexts y cómo manejarlas (y un ejemplo claro de solapamiento es el que decíamos antes, una visión distinta de un mismo concepto según a quién preguntes, o el mismo concepto llamado de distintas formas según a quién preguntes – es la misma entidad pero cada uno la ve a su manera).
Un solo modelo de dominio será un problema cuando el número de entidades sea muy alto, debido a su volumen y a las relaciones entre las mismas, estará todo muy acoplado e iremos de cabeza al BBM. Dividir es siempre una buena idea y reflejará los distintos subsistemas de la organización que estamos modelando. La misma entidad puede ser muy diferente en ambos subdominios, por ejemplo en Billing un pedido es un mero contenedor de información, pero en Sales es un objeto rico con comportamiento para agregarle líneas, etc. ¿Por qué acoplar todo ese comportamiento a Billing si no lo necesita? Compartir esa entidad entre bounded contexts no parece una buena idea, probablemente sólo necesite el id, el importe y poco más del pedido.
Opciones para resolver este overlap:
•   Un solo modelo de dominio 
•   Un Shared Kernel con las entidades comunes y varios bounded-contexts
•   Varios bounded-contexts cada uno con su definición de entidades
Normalmente se usa un bounded-context por cada departamento de la organización (RRHH, Ventas, etc.) pero la división puede ser cualquier otra. También suele haber un equipo distinto trabajando en cada bounded-context. La opción del shared kernel funciona bien si está todo muy claro, sino es peligroso y el equipo 1 podría joder al equipo 2 si cambia algo.
Context map. Un diagrama donde cada elemento es un bounde-context y suministra una visión comprensiva del sistema siendo diseñado. Las relaciones entre elementos en este diagrama (recordar que son bounded-context) pueden ser upstream context o downstream context (patrones relacionales definidos por DDD). Upstream context (u) dice que un cambio en este contexto podría forzar cambios en el contexto downstream (d) relacionado, aquí downstream es pasivo, si hay cambios en “u”, “d” podría cambiar. 
Hay otros tipos de relaciones: ACL (Anti-corruption layer), Conformist, Customer/Supplier, Partnership o Shared Kernel.
