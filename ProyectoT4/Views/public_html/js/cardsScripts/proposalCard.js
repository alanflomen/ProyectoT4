scriptsManager.proposal = {
    /**
     * @type {Operacion}
     */
    context: null,
    apiConsts:{
        addToList: "ResultadoBusqueda/AgregaLista",
        deleteFromList: "ResultadoBusqueda/EliminarLista",
        typeWishlist: 'w',
        typeHas: 'l',
        typePlayed: 'j'
    }
}

$.extend(true,scriptsManager.detail,
    new CardScript("proposalCard.js",
        function(){
            let clientStatus = new XMLHttpRequest();
            clientStatus.open('GET', this.jsonSource);
            clientStatus.onreadystatechange = function() {
                if(this.readyState == 4 && this.status == 200){
                    console.log(clientStatus.responseText);
                    let parsedObj = JSON.parse(clientStatus.responseText);
                    scriptsManager.detail.currentGame = parsedObj;
                    ShowData(parsedObj.JuegoBuscado, "JuegoBuscado_");
                    
                }
                else(this.readyState == 4 && this.status == 404)
                    console.error("Didn't sent a response");
            }
            clientStatus.send();
        }
    )
);

scriptsManager.switchPage(scriptsManager.status);