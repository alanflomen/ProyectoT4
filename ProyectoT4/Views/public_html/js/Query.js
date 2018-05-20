/**
 * 
 * @param {string} route 
 * @param {array} params 
 * @param {boolean} isPost
 */
const Query = function(route,params,isPost){
    if(!route) {
        console.log("Route is null, it's impossible to perform the query");
        return;
    }

    isPost = isPost === undefined ? false : isPost;

    let request = new XMLHttpRequest();
        request.open('GET', route);
        request.onreadystatechange = function() {
            if(this.readyState == 4 && this.status == 200){
                console.log(request.responseText);
                let parsedObj = JSON.parse(request.responseText);
                ShowData(parsedObj);
                // scriptsManager.status.setScreen(parsedObj.version,parsedObj.ip,parsedObj.region);
            }
            else if(this.readyState == 4 && this.status == 404)
                console.error(route + " didn't sent a response");
            
            else{
                console.error(route + " Failed");
                console.error(request.response);
            }
            
        }
    request.send();
    
}