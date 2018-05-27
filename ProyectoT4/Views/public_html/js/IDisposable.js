class IDisposable {
    constructor(init,dispose){
        this.init = init;
        this.dispose = dispose;
        console.log(this);
    }
}

var Pages = [];