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