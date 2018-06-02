cards.forEach(function(item,index){
    document.writeln('<div id="' + item + 'Container" class="w3-padding w3-hide w3-twothird">');
    document.writeln('<div id="' + item + '" class="w3-container w3-border-green w3-border w3-round-medium w3-dark-gray w3-hover-blue-gray w3-animate-bottom w3-animate-opacity"></div>');
    document.writeln('</div>');
    document.writeln('<div id="' + item + 'ContainerHelp" class="w3-padding w3-hide w3-rest">');
    document.writeln('<div id="' + item + 'Help" class="w3-container w3-border-green w3-border w3-round-medium w3-dark-gray w3-hover-blue-gray w3-animate-bottom w3-animate-opacity"></div>');
    document.writeln('</div>');
});