//? the properties of this object are defined in /cardsScripts
var scriptsManager = {
    activeScript: null,
    switchPage: function(page){
        if (page == null || page == undefined){
            console.error("Cannot switch to null/undefinded page");
        }
        else{
            try{
                if(this.activeScript != null){
                    this.activeScript.dispose();
                    //! console.log(this.activeScript.scriptName + " disposed");
                }
                this.activeScript = page;
                this.activeScript.start();
                console.log("Attempt to switch to " + page.scriptName + " script");
            }
            catch(err){
                console.error(err.message);
            }
        }
    }
};


/**
 * Creates a new CardScript
 * @param {String} name
 * @param {function} start
 * @param {function} dispose
 * @param {String} jsonSource
 * @example
 * CardScript('Card Name', function(){}, function(){}, 'JSON URI')
 * @returns {CardScript}
 */
function CardScript(name,start,dispose,jsonSource){
    this.scriptName = name || "No name";
    this.start = start || function(){console.log(this.scriptName + " started")};
    this.dispose = dispose || function(){console.log(this.scriptName + " disposed")};
    this.jsonSource = jsonSource;
    
    if(!jsonSource)
        console.warn("jsonSource is null in " + name + " checkout this, it may be an error");
}