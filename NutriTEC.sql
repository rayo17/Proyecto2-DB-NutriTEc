PGDMP                          {            NutriTEC    15.3    15.3 (    <           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            =           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            >           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            ?           1262    16399    NutriTEC    DATABASE     }   CREATE DATABASE "NutriTEC" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Spanish_Spain.1252';
    DROP DATABASE "NutriTEC";
                postgres    false            �            1259    16446    administrador    TABLE     �   CREATE TABLE public.administrador (
    correo character varying(100) NOT NULL,
    contrasena character varying(100) NOT NULL
);
 !   DROP TABLE public.administrador;
       public         heap    postgres    false            �            1259    16436    cliente    TABLE     S  CREATE TABLE public.cliente (
    correo character varying(50) NOT NULL,
    nombre character varying(20) NOT NULL,
    apellido1 character varying(20) NOT NULL,
    apellido2 character varying(20) NOT NULL,
    contrasena character varying(20) NOT NULL,
    fecha_nacimiento date NOT NULL,
    edad integer NOT NULL,
    peso integer NOT NULL,
    imc integer NOT NULL,
    cintura integer NOT NULL,
    pmusculo integer NOT NULL,
    cuello integer NOT NULL,
    caderas integer NOT NULL,
    pgrasa integer NOT NULL,
    consumo_diario_c integer NOT NULL,
    fecha_medicion date NOT NULL
);
    DROP TABLE public.cliente;
       public         heap    postgres    false            �            1259    16496    cobro    TABLE     �   CREATE TABLE public.cobro (
    id_nutri character varying(20) NOT NULL,
    cod_barras_nutri integer NOT NULL,
    plan character varying(100) NOT NULL,
    monto_t integer NOT NULL,
    descuento integer NOT NULL
);
    DROP TABLE public.cobro;
       public         heap    postgres    false            �            1259    16468    consumo    TABLE     R  CREATE TABLE public.consumo (
    correo_cliente character varying(50) NOT NULL,
    fecha date NOT NULL,
    desayuno character varying(250) NOT NULL,
    merienda_m character varying(250) NOT NULL,
    almuerzo character varying(250) NOT NULL,
    merienda_t character varying(250) NOT NULL,
    cena character varying(250) NOT NULL
);
    DROP TABLE public.consumo;
       public         heap    postgres    false            �            1259    16480    estado_de_producto    TABLE     y   CREATE TABLE public.estado_de_producto (
    codigo_barra integer NOT NULL,
    estado character varying(20) NOT NULL
);
 &   DROP TABLE public.estado_de_producto;
       public         heap    postgres    false            �            1259    16429    nutricionista    TABLE     �  CREATE TABLE public.nutricionista (
    cedula character varying(20) NOT NULL,
    cod_barras integer NOT NULL,
    nombre character varying(20) NOT NULL,
    apellido1 character varying(20) NOT NULL,
    apellido2 character varying(20) NOT NULL,
    foto bytea,
    num_tarj_credi integer NOT NULL,
    edad integer NOT NULL,
    fecha_nacimiento date NOT NULL,
    contrasena character varying(20) NOT NULL,
    correo character varying(20) NOT NULL,
    imc integer NOT NULL,
    peso integer NOT NULL
);
 !   DROP TABLE public.nutricionista;
       public         heap    postgres    false            �            1259    16486    nutricionista_asigna_cliente    TABLE     �   CREATE TABLE public.nutricionista_asigna_cliente (
    id_nutricionista character varying(20) NOT NULL,
    cod_barras_nutri integer NOT NULL,
    correo_cliente character varying(50) NOT NULL,
    fecha_i date NOT NULL,
    fecha_f date NOT NULL
);
 0   DROP TABLE public.nutricionista_asigna_cliente;
       public         heap    postgres    false            �            1259    16451    plan    TABLE     4  CREATE TABLE public.plan (
    nombre_plan character varying(100) NOT NULL,
    desayuno character varying(255) NOT NULL,
    merienda_m character varying(255) NOT NULL,
    almuerzo character varying(255) NOT NULL,
    merienda_t character varying(255) NOT NULL,
    cena character varying(255) NOT NULL
);
    DROP TABLE public.plan;
       public         heap    postgres    false            �            1259    16441    producto    TABLE     �  CREATE TABLE public.producto (
    codigo_barra integer NOT NULL,
    nombre character varying(20) NOT NULL,
    grasa integer NOT NULL,
    taman_porcion integer NOT NULL,
    energia integer NOT NULL,
    descripcion character varying(200),
    proteina integer NOT NULL,
    sodio integer NOT NULL,
    hierro integer NOT NULL,
    calcio integer NOT NULL,
    vitaminas character varying(150) NOT NULL,
    carbohidratos integer NOT NULL
);
    DROP TABLE public.producto;
       public         heap    postgres    false            �            1259    16491 
   tipo_cobro    TABLE     �   CREATE TABLE public.tipo_cobro (
    cedula character varying(20) NOT NULL,
    cod_barras_nutri integer NOT NULL,
    tipo_cobro character varying(100) NOT NULL
);
    DROP TABLE public.tipo_cobro;
       public         heap    postgres    false            3          0    16446    administrador 
   TABLE DATA           ;   COPY public.administrador (correo, contrasena) FROM stdin;
    public          postgres    false    217   ?9       1          0    16436    cliente 
   TABLE DATA           �   COPY public.cliente (correo, nombre, apellido1, apellido2, contrasena, fecha_nacimiento, edad, peso, imc, cintura, pmusculo, cuello, caderas, pgrasa, consumo_diario_c, fecha_medicion) FROM stdin;
    public          postgres    false    215   \9       9          0    16496    cobro 
   TABLE DATA           U   COPY public.cobro (id_nutri, cod_barras_nutri, plan, monto_t, descuento) FROM stdin;
    public          postgres    false    223   y9       5          0    16468    consumo 
   TABLE DATA           j   COPY public.consumo (correo_cliente, fecha, desayuno, merienda_m, almuerzo, merienda_t, cena) FROM stdin;
    public          postgres    false    219   �9       6          0    16480    estado_de_producto 
   TABLE DATA           B   COPY public.estado_de_producto (codigo_barra, estado) FROM stdin;
    public          postgres    false    220   �9       0          0    16429    nutricionista 
   TABLE DATA           �   COPY public.nutricionista (cedula, cod_barras, nombre, apellido1, apellido2, foto, num_tarj_credi, edad, fecha_nacimiento, contrasena, correo, imc, peso) FROM stdin;
    public          postgres    false    214   �9       7          0    16486    nutricionista_asigna_cliente 
   TABLE DATA           |   COPY public.nutricionista_asigna_cliente (id_nutricionista, cod_barras_nutri, correo_cliente, fecha_i, fecha_f) FROM stdin;
    public          postgres    false    221   �9       4          0    16451    plan 
   TABLE DATA           ]   COPY public.plan (nombre_plan, desayuno, merienda_m, almuerzo, merienda_t, cena) FROM stdin;
    public          postgres    false    218   
:       2          0    16441    producto 
   TABLE DATA           �   COPY public.producto (codigo_barra, nombre, grasa, taman_porcion, energia, descripcion, proteina, sodio, hierro, calcio, vitaminas, carbohidratos) FROM stdin;
    public          postgres    false    216   ':       8          0    16491 
   tipo_cobro 
   TABLE DATA           J   COPY public.tipo_cobro (cedula, cod_barras_nutri, tipo_cobro) FROM stdin;
    public          postgres    false    222   D:       �           2606    16450     administrador administrador_pkey 
   CONSTRAINT     b   ALTER TABLE ONLY public.administrador
    ADD CONSTRAINT administrador_pkey PRIMARY KEY (correo);
 J   ALTER TABLE ONLY public.administrador DROP CONSTRAINT administrador_pkey;
       public            postgres    false    217            �           2606    16440    cliente cliente_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public.cliente
    ADD CONSTRAINT cliente_pkey PRIMARY KEY (correo);
 >   ALTER TABLE ONLY public.cliente DROP CONSTRAINT cliente_pkey;
       public            postgres    false    215            �           2606    16500    cobro cobro_pkey 
   CONSTRAINT     f   ALTER TABLE ONLY public.cobro
    ADD CONSTRAINT cobro_pkey PRIMARY KEY (id_nutri, cod_barras_nutri);
 :   ALTER TABLE ONLY public.cobro DROP CONSTRAINT cobro_pkey;
       public            postgres    false    223    223            �           2606    16474    consumo consumo_pkey 
   CONSTRAINT     ^   ALTER TABLE ONLY public.consumo
    ADD CONSTRAINT consumo_pkey PRIMARY KEY (correo_cliente);
 >   ALTER TABLE ONLY public.consumo DROP CONSTRAINT consumo_pkey;
       public            postgres    false    219            �           2606    16484 *   estado_de_producto estado_de_producto_pkey 
   CONSTRAINT     z   ALTER TABLE ONLY public.estado_de_producto
    ADD CONSTRAINT estado_de_producto_pkey PRIMARY KEY (codigo_barra, estado);
 T   ALTER TABLE ONLY public.estado_de_producto DROP CONSTRAINT estado_de_producto_pkey;
       public            postgres    false    220    220            �           2606    16490 >   nutricionista_asigna_cliente nutricionista_asigna_cliente_pkey 
   CONSTRAINT     �   ALTER TABLE ONLY public.nutricionista_asigna_cliente
    ADD CONSTRAINT nutricionista_asigna_cliente_pkey PRIMARY KEY (id_nutricionista, cod_barras_nutri, correo_cliente);
 h   ALTER TABLE ONLY public.nutricionista_asigna_cliente DROP CONSTRAINT nutricionista_asigna_cliente_pkey;
       public            postgres    false    221    221    221            �           2606    16435     nutricionista nutricionista_pkey 
   CONSTRAINT     n   ALTER TABLE ONLY public.nutricionista
    ADD CONSTRAINT nutricionista_pkey PRIMARY KEY (cedula, cod_barras);
 J   ALTER TABLE ONLY public.nutricionista DROP CONSTRAINT nutricionista_pkey;
       public            postgres    false    214    214            �           2606    16457    plan plan_pkey 
   CONSTRAINT     U   ALTER TABLE ONLY public.plan
    ADD CONSTRAINT plan_pkey PRIMARY KEY (nombre_plan);
 8   ALTER TABLE ONLY public.plan DROP CONSTRAINT plan_pkey;
       public            postgres    false    218            �           2606    16445    producto producto_pkey 
   CONSTRAINT     ^   ALTER TABLE ONLY public.producto
    ADD CONSTRAINT producto_pkey PRIMARY KEY (codigo_barra);
 @   ALTER TABLE ONLY public.producto DROP CONSTRAINT producto_pkey;
       public            postgres    false    216            �           2606    16495    tipo_cobro tipo_cobro_pkey 
   CONSTRAINT     n   ALTER TABLE ONLY public.tipo_cobro
    ADD CONSTRAINT tipo_cobro_pkey PRIMARY KEY (cedula, cod_barras_nutri);
 D   ALTER TABLE ONLY public.tipo_cobro DROP CONSTRAINT tipo_cobro_pkey;
       public            postgres    false    222    222            �           2606    16501 *   cobro cobro_id_nutri_cod_barras_nutri_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.cobro
    ADD CONSTRAINT cobro_id_nutri_cod_barras_nutri_fkey FOREIGN KEY (id_nutri, cod_barras_nutri) REFERENCES public.nutricionista(cedula, cod_barras);
 T   ALTER TABLE ONLY public.cobro DROP CONSTRAINT cobro_id_nutri_cod_barras_nutri_fkey;
       public          postgres    false    223    223    214    214    3209            �           2606    16511 #   consumo consumo_correo_cliente_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.consumo
    ADD CONSTRAINT consumo_correo_cliente_fkey FOREIGN KEY (correo_cliente) REFERENCES public.cliente(correo);
 M   ALTER TABLE ONLY public.consumo DROP CONSTRAINT consumo_correo_cliente_fkey;
       public          postgres    false    215    3211    219            �           2606    16526 7   estado_de_producto estado_de_producto_codigo_barra_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.estado_de_producto
    ADD CONSTRAINT estado_de_producto_codigo_barra_fkey FOREIGN KEY (codigo_barra) REFERENCES public.producto(codigo_barra);
 a   ALTER TABLE ONLY public.estado_de_producto DROP CONSTRAINT estado_de_producto_codigo_barra_fkey;
       public          postgres    false    216    3213    220            �           2606    16521 M   nutricionista_asigna_cliente nutricionista_asigna_cliente_correo_cliente_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.nutricionista_asigna_cliente
    ADD CONSTRAINT nutricionista_asigna_cliente_correo_cliente_fkey FOREIGN KEY (correo_cliente) REFERENCES public.cliente(correo);
 w   ALTER TABLE ONLY public.nutricionista_asigna_cliente DROP CONSTRAINT nutricionista_asigna_cliente_correo_cliente_fkey;
       public          postgres    false    215    3211    221            �           2606    16516 \   nutricionista_asigna_cliente nutricionista_asigna_cliente_id_nutricionista_cod_barras_n_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.nutricionista_asigna_cliente
    ADD CONSTRAINT nutricionista_asigna_cliente_id_nutricionista_cod_barras_n_fkey FOREIGN KEY (id_nutricionista, cod_barras_nutri) REFERENCES public.nutricionista(cedula, cod_barras);
 �   ALTER TABLE ONLY public.nutricionista_asigna_cliente DROP CONSTRAINT nutricionista_asigna_cliente_id_nutricionista_cod_barras_n_fkey;
       public          postgres    false    3209    221    214    214    221            �           2606    16506 2   tipo_cobro tipo_cobro_cedula_cod_barras_nutri_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.tipo_cobro
    ADD CONSTRAINT tipo_cobro_cedula_cod_barras_nutri_fkey FOREIGN KEY (cedula, cod_barras_nutri) REFERENCES public.nutricionista(cedula, cod_barras);
 \   ALTER TABLE ONLY public.tipo_cobro DROP CONSTRAINT tipo_cobro_cedula_cod_barras_nutri_fkey;
       public          postgres    false    214    214    3209    222    222            3      x������ � �      1      x������ � �      9      x������ � �      5      x������ � �      6      x������ � �      0      x������ � �      7      x������ � �      4      x������ � �      2      x������ � �      8      x������ � �     