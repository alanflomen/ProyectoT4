var sadAJAX = "<h1>Something went wrong</h1><h2>Please wait a moment and refresh the tab.</h2>";

function w3_open() {
    document.getElementById("sidebar").style.display = "block";
}
function w3_close() {
    document.getElementById("sidebar").style.display = "none";
}

function loadCard(item){
    window.history.pushState(null,item,item);
    if(scriptsManager[item] != null){
        scriptsManager.switchPage(scriptsManager[item]);
        console.log(item + " script loaded");
    }
    else {
        var client = new XMLHttpRequest();
        client.open('GET', 'cards/'+ item + '.html');
        client.onreadystatechange = function() {
            if(this.readyState == 4 && this.status == 200){
                console.log(client.responseText);
                $("#"+item).empty().html(client.responseText);
            }
            else if(this.status >= 400){
                // TODO poner else if
                $("#"+item).empty().html(sadAJAX);
            }
        }
        client.send();
    }
}

/**
 * 
 * @param {String} destination 
 */
function navigateToCard(destination){
    loadCard(destination);
    // loadHelp(destination);
    cards.forEach(function(item,index){
        if(item == destination){
            document.getElementById(item + "Container").classList.remove("w3-hide");
            // document.getElementById(item + "ContainerHelp").classList.remove("w3-hide");
        }
        else if(item != null){
            document.getElementById(item + "Container").classList.add("w3-hide");
            // document.getElementById(item + "ContainerHelp").classList.add("w3-hide");
        }
    });
    
    w3_close();
}

// Initial card
// navigateToCard(cards[0]);
// navigateToCard('detail');