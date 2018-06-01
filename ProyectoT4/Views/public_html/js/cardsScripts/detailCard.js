scriptsManager.detail = {}

$.extend(true,scriptsManager.detail,
    new CardScript("detailCard.js",
        function(){
            let clientStatus = new XMLHttpRequest();
            clientStatus.open('GET', this.jsonSource);
            clientStatus.onreadystatechange = function() {
                if(this.readyState == 4 && this.status == 200){
                    console.log(clientStatus.responseText);
                    let parsedObj = JSON.parse(clientStatus.responseText);
                    ShowData(parsedObj);
                }
                else(this.readyState == 4 && this.status == 404)
                    console.error("Didn't sent a response");
            }
            clientStatus.send();
        }
    )
);

scriptsManager.switchPage(scriptsManager.status);