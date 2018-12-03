//עץ להצגת הנתונים
var main = document.querySelector('main'),
tree = new VanillaTree(main, {
    contextmenu: [{
        label: 'Menu 1',
        action: function (id) {
            alert('Menu 1 ' + id);
        }
    }, {
        label: 'Menu 2',
        action: function (id) {
            alert('Menu 2 ' + id);
        }
    }]
});
tree.add({
    label: 'Label A',
    id: 'a',
    opened: true
});

tree.add({
    label: 'Label B',
    id: 'b'
});

tree.add({
    label: 'Label A.A',
    parent: 'a',
    id: 'a.a',
    opened: true,
    selected: true
});

tree.add({
    label: 'Label A.A.A',
    parent: 'a.a'
});
tree.add({
    label: 'Label A.A.B',
    parent: 'a.a'
});

tree.add({
    label: 'Label B.A',
    parent: 'b'
});
 
tree.add({	   
    label: 'Label A',	   
    id: 'a',	   
    opened: true	   
});	   	 	   
tree.add({	   
	  label: 'Label B',	   
	  id: 'b'	   
});	   
	 	   
	tree.add({	   
    label: 'Label A.A',	   
    parent: 'a',	   
    id: 'a.a',	   
    opened: true,	   
    selected: true	   
	});	   
	 	   
	tree.add({	   
 	  label: 'Label A.A.A',	   
  	  parent: 'a.a'	   
	});	   
	tree.add({	   
    	  label: 'Label A.A.B',	   
    	  parent: 'a.a'	   
	});	   
	 	   
	tree.add({	   
	    label: 'Label B.A',	   
      parent: 'b'	   
	});	 

 
// add new nodes	   
tree.add(options);	   
 	   
// move a node to parent	   
tree.move(id, parentId);	   
 	   
// remove a node	   
tree.remove(id);	   
 	   
// open a node	   
tree.open(id);	   
 	   
// close a node	   
tree.close(id);	   
 	   
// toggle a node	   
tree.toggle(id);	   
 	   
// select a node	   
tree.select(id);	 

 
//01	main.addEventListener('vtree-add', function(evt) {	   
//02	  // when added	   
//03	});	   
//04	 	   
//05	main.addEventListener('vtree-remove', function(evt) {	   
//06	  // when closed	   
//07	});	   
//08	 	   
//09	main.addEventListener('vtree-move', function(evt) {	   
//10	  // when moved	   
//11	});	   
//12	 	   
//13	main.addEventListener('vtree-open', function(evt) {	   
//14	  // when opened	   
//15	});	   
//16	 	   
//17	main.addEventListener('vtree-close', function(evt) {	   
//    18	  // when closed	   
//    19	});	   
//20	 	   
//21	main.addEventListener('vtree-select', function(evt) {	   
//    22	  // when selected	   
//    23	});	 
