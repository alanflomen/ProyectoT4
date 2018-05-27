cards.forEach(function(item,index){
    document.writeln('<div id="' + item + 'Container" class="w3-padding w3-twothird w3-hide">');
    document.writeln('<div id="' + item + '" class="w3-container w3-card w3-round-medium w3-white w3-hover-shadow w3-animate-bottom w3-animate-opacity"></div>');
    document.writeln('</div>');
    document.writeln('<div id="' + item + 'ContainerHelp" class="w3-padding w3-rest w3-hide">');
    document.writeln('<div id="' + item + 'Help" class="w3-container w3-card w3-round-medium w3-white w3-hover-shadow w3-animate-bottom w3-animate-opacity"></div>');
    document.writeln('</div>');
});