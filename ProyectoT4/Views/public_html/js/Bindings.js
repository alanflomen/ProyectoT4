const backend = "localhost:20995";

/**
 * 
 * @param {Array} data 
 * @param {String} prefix
 * @returns {Void}
 */
const ShowData = function(data, prefix){
    if(!data)
        console.warn("There was no data passed");
    for(var property in data) { 
        // console.log(property);
        // console.log(data[property]);
        try {
            if(prefix)
            Replace(prefix + property,data[property]);
            else
                Replace(property,data[property]);    
        } catch (error) {
            console.warn(property + " sent the following error:");
            console.warn(error);
        }
            
    }
}

/**
 * This function replaces the text in the HTML tags
 * @param {string} id 
 * @param {string} text 
 */
const Replace = function(id,text){
    if(!id) {
        console.error("The id to replace is null");
        return;
    }
    let htmlElement = document.getElementById(id);
    if(htmlElement != null && htmlElement.tagName == "img")
    {
        console.error(id + " is image and wants to src=" + text);
        htmlElement.setAttribute("src",text);
        htmlElement.setAttribute("alt",text);
    }
    else if (htmlElement instanceof Array)
        console.error("Arrays not supported yet");
    else
        htmlElement.innerText = text;
}

/**
 * @function
 * @param {*} values
 * @param {String} apiURL
 * @param {Function} callback
 */
const sendToServer = function(values,apiURL, callback)
{
    if(!values || !apiURL){
        console.error("Not enough parameters to execute");
        return;
    }
    let responseQuery = $.param(values);
    console.log(responseQuery);
    
    client.open('POST', backend + "/" + apiURL + '?' + responseQuery);
    client.onreadystatechange = function() {
        console.log("Received info");
        // document.getElementById('network_loadingCircle').classList.add('w3-hide');
        // scriptsManager.network.loadInfo();
        if(this.readyState == 4 && this.status == 200)
            if(callback) callback();
        else
            console.error("Something went wrong, check your connection");
    };
    client.send();
}