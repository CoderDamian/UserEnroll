-- ================================================================
-- Create the tables, editioning views, triggers, and sequences
-- Schema: CTB
-- =================================================================

-- con usuario ctb
create table usuarios# (
      nombres             varchar2(100)
    , apellidos           varchar2(100)
    , correo_electronico  varchar2(100)
    , contrasena          varchar2(25)
    , codigo_verificacion varchar2(10)
    , numero_reintento    number(1)
    , estado              number(1)
);
/

comment on column usuarios#.contrasena is 'Por el momento no existe ninguna clase de restriccion para la conformacion de la contrasena';
comment on column usuarios#.codigo_verificacion is 'Codigo de verificación que se envía al correo del usuario';
comment on column usuarios#.numero_reintento is 'Se permite reintentar hasta tres veces antes de invalidarlo';
comment on column usuarios#.estado is '(1) el usuario es valido, (0) el usuario es invalido, (Null) el usuario aun no ha completado proceso de registro';
/

alter table usuarios# add constraint usua_pk primary key (correo_electronico);
alter table usuarios# modify nombres constraint usua_nomb_nn not null;
alter table usuarios# modify apellidos constraint usua_apel_nn not null;
alter table usuarios# modify contrasena constraint usua_cont_nn not null;
alter table usuarios# add constraint usuar_nume_ch check (numero_reintento between 1 and 3);
/

create or replace editioning view usuarios as select * from usuarios#;
/

grant select, insert, update, delete on ctb.usuarios to ctb_code;
/

-- con el usuario ctb_code
create or replace synonym usuarios for ctb.usuarios;

