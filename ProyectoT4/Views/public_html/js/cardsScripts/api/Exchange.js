/**
 * @class Operacion
 */
class Operacion {
    constructor(){
        /**
         * @type {Number}
         */
        this.IdOperacion;
        /**
         * @type {String}
         */
        this.UsuarioEnvia;
        /**
         * @type {String}
         */
        this.UsuarioRecibe;
        /**
         * @type {Datetime}
         */
        this.Fecha;
        /**
         * @type {Number}
         */
        this.JuegoBuscado;
        /**
         * @type {Number}
         */
        this.JuegoOfrecido1;
        /**
         * @type {Number}
         */
        this.JuegoOfrecido2;
        /**
         * @type {Number}
         */
        this.JuegoOfrecido3;
        /**
         * Estado = propuesta enviada, aceptada o rechazada...etc
         * @type {String}
         */
        this.Estado;
    }
}