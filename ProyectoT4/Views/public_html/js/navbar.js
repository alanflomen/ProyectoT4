var cards = [
    "myProfile",
    "myGames",
    "myWishlist",
    null,
    "proposals",   
    "search",
    null,
    "settings"
];

cards.forEach(function(item,index){
    if(item == null){
        document.writeln('<hr>');
    }
    else{
        var itemForFx = "'" + item + "'";
        var itemForBar = item.split(/(?=[A-Z])/).join(" ");
        itemForBar = itemForBar.charAt(0).toUpperCase() + itemForBar.slice(1);
        document.writeln('<a href="#" class="w3-bar-item w3-button" onclick="navigateToCard(' + itemForFx + ')">' + itemForBar + '</a>');
        console.log('<a href="#" class="w3-bar-item w3-button" onclick="navigateToCard(' + itemForFx + ')">' + itemForBar + '</a>');
    }
}
);
