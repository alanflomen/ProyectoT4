scriptsManager.detail = {
    currentGame: null,
    apiConsts:{
        addToList: "ResultadoBusqueda/AgregaLista",
        deleteFromList: "ResultadoBusqueda/EliminarLista",
        typeWishlist: 'w',
        typeHas: 'l',
        typePlayed: 'j'
    },
    addToWanted: function(){
        sendToServer(
            {
                idJuego: scriptsManager.detail.currentGame.JuegoBuscado.Id,
                idUsuario: scriptsManager.detail.currentGame.IdUsuario,
                tipo: scriptsManager.detail.apiConsts.typeWishlist
            },
            currentGame.wishlist ? scriptsManager.detail.apiConsts.deleteFromList : scriptsManager.detail.apiConsts.addToList);
    },
    addToOwned: function(){
        sendToServer(
            {
                idJuego: scriptsManager.detail.currentGame.JuegoBuscado.Id,
                idUsuario: scriptsManager.detail.currentGame.IdUsuario,
                tipo: scriptsManager.detail.apiConsts.typeHas
            },
            currentGame.loTengo ? scriptsManager.detail.apiConsts.deleteFromList : scriptsManager.detail.apiConsts.addToList);
    },
    addToPlayed: function(){
        sendToServer(
            {
                idJuego: scriptsManager.detail.currentGame.JuegoBuscado.Id,
                idUsuario: scriptsManager.detail.currentGame.IdUsuario,
                tipo: scriptsManager.detail.apiConsts.typePlayed
            },
            currentGame.yaLoJugue ? scriptsManager.detail.apiConsts.deleteFromList : scriptsManager.detail.apiConsts.addToList);
    }
}

$.extend(true,scriptsManager.detail,
    new CardScript("detailCard.js",
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