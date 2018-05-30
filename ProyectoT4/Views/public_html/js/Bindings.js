/**
 * 
 * @param {Array} data 
 */
const ShowData = function(data){
    for(var property in data) { 
        // console.log(property);
        // console.log(data[property]);
        Replace(property,data[property]);
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
        htmlElement.setAttribute("src",text);
        htmlElement.setAttribute("alt",text);
    }
    else if (htmlElement instanceof Array)
        console.error("Arrays not supported yet");
    else
        htmlElement.innerText = text;
}