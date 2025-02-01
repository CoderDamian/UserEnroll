create or replace function add_new_user (
    p_nombres            in varchar2
  , p_apellidos          in varchar2
  , p_correo_electronico in varchar2
  , p_contrasena         in varchar2
) return varchar2 is

    l_dominio_corporativo varchar2(10) := 'gmail.com';
    l_dominio_correo      varchar2(100);    -- dominio del correo indicado por el usuario
    l_posicion            number(2);        -- posicion del caracter @ en el correo indicado por el usuario
    l_codigo_verificacion varchar2(5);      -- codigo de verificacion que se enviara al correo del usuario 

    type l_mensajes_aat is table of varchar2(100) index by pls_integer;
    l_mensajes            l_mensajes_aat;  -- posibles mensajes de error que pueden ocurrir en el procedimiento

begin

    -- crear los mensajes de error
    l_mensajes(0) := 'falta indicar los nombres completos';
    l_mensajes(1) := 'falta indicar los apellidos completos';
    l_mensajes(2) := 'falta indicar el correo electronico';
    l_mensajes(3) := 'el correo electronico no es valido';
    l_mensajes(4) := 'el correo no pertenece al dominio autorizado';
    l_mensajes(5) := 'la contrasena no puede ser null';

    -- regla de negocio: debe indicar un nombre
    if ( p_nombres is null ) then
        raise_application_error(-20000, l_mensajes(0));
    end if;

    -- regla de negocio: debe indicar un apellido
    if ( p_apellidos is null ) then
        raise_application_error(-20000, l_mensajes(1));
    end if;

    -- regla de negocio: debe indicar un correo electronico
    if ( p_correo_electronico is null ) then
        raise_application_error(-20000, l_mensajes(2));
    end if;

    -- regla de negocio: el correo electronico debe ser valido
    l_posicion := instr(p_correo_electronico, '@');

    if ( l_posicion = 0 ) then
        raise_application_error(-20000, l_mensajes(3));
    end if;

    -- regla de negocio: el correo debe pertenece a un dominio autorizado

    -- extraer el dominio del correo indicado por el usuario
    l_dominio_correo := lower(substr(p_correo_electronico, l_posicion + 1));

    if (l_dominio_correo != l_dominio_corporativo) then
        raise_application_error(-20000, l_mensajes(4));
    end if;

    -- regla de negocio: la contrasena no puede ser null
    if (p_contrasena is null) then
        raise_application_error(-20000, l_mensajes(5));
    end if;

    -- generar codigo de verificacion de 5 caracteres de longitud
    l_codigo_verificacion := dbms_random.string('p', 5);    

    -- ingresar los datos del usuario
    insert into usuarios (
        nombres
        , apellidos
        , correo_electronico
        , contrasena
        , codigo_verificacion
        , numero_reintento
        , estado
        ) values (
        p_nombres
        , p_apellidos
        , p_correo_electronico
        , p_contrasena
        , l_codigo_verificacion
        , null
        , null  -- el usuario aun no ha completado proceso de registro
        );

    -- enviar al correo del usuario el codigo de verificacion

    -- retornar el codigo de verificacion
    return l_codigo_verificacion;

exception
    when others then
        raise;
end;
