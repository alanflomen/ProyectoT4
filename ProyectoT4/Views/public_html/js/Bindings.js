const ShowData = function(data){
    for(var property in data) { 
        // console.log(property);
        // console.log(data[property]);
        Replace(property,data[property]);
    }
}

/**
 * 
 * @param {string} id 
 * @param {string} text 
 */
const Replace = function(id,text){
    if(!id) {
        console.error("The id to replace is null");
        return;
    }
    document.getElementById(id).innerText = text;
}