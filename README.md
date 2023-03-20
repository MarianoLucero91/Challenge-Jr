# Challenge-Jr

Para utilizar la aplicación, deberan seguir los siguientes pasos:
1) inicializar la API en el back-end, ejecutando la solucion con visual studio.
2) ir a la carpeta front-end, y con git bash, ejecutar los comandos npm install y npm run dev.
3) el mismo corre en las siguientes URLs: http://localhost:5073/coberturas   -------> Lista de coberturas
                                           http://localhost:5073/polizas      -------> Lista de polizas con coberturas asociadas + monto total asegurado.
                                           http://localhost:5073/alta-poliza  -------> Ruta para dar de alta polizas.


Como deuda técnica por falta de tiempo y/o conocimiento puedo mencionar los siguientes items:
- El front-end fue realizado con Material UI, pero tiene diseños por defecto y muchas veces muy básicos.
- El form de Alta poliza, se renderizan las coberturas a agregar, una pegada a la otra y en la misma linea. Lo correcto sería renderizar una debajo de la otra.
- Cuando se borran o agregan coberturas y polizas, la página no se actualiza por si sola, sino que para esto es necesario recargar la pagina.

Como bien mencioné en el mail, por algun motivo que desconozco, el repository que me entregaron no contenía ninguna plantilla para el front end. Por esto, realicé uno por mi cuenta con React intentando cumplir con lo solicitado en el challenge, entendiendo que hay muchisimos puntos por mejorar y aprender.

Muchas gracias.