PennController.ResetPrefix(null);
PennController.AddHost('http://lacqlab.scripts.mit.edu/experiments/both/')

PennController.Template( 'TrainingItems.csv',
    row => PennController(
    defaultImage
        .settings.size(200,200)
        .settings.center()
    ,
    defaultText
        .print()
        .settings.center()
        .settings.bold()
    ,
    defaultSelector
        .settings.frame('solid 3px red')
        .settings.log()
    ,
    newVar('a',row.A_set)
    ,
    //newCanvas('c1',600,200)//.settings.css("border", "solid 1px black")
    //,
//newCanvas('c1',600,200)//.settings.css("border", "solid 3px black")
 //   ,
    newCanvas('big',1200,150),
    getVar('a')
    .test.is(1)
    .success(
        newCanvas('c11',200,150).settings.css("border", "solid 3px black"),
        newSelector('t11'),
            getCanvas('c11')
            .settings.add('center at 50%',0,newImage('t11',row.A_Image).settings.selector('t11')),
        newVar('select', 0),
        getSelector('t11')
        .settings.callback(
            getVar('select')
            .set(v => v+1)
            .test.is(2)
            .success(
                getSelector('t11').unselect(),
                getVar('select')
                .set(v => 0),
            )
        )
        //,getCanvas('c11').print('center at 33%',350)
        ,getCanvas('big').settings.add('center at 36%',0,getCanvas('c11'))
        )
    .failure(
        getVar('a')
        .test.is(2)
        .success(
            newSelector('t21'),
            newSelector('t22'),
            newCanvas('c12',400,150)
                .settings.css("border", "solid 3px black")
                .settings.add(0,0,newImage('t21',row.A_Image).settings.selector('t21'))
                .settings.add(200,0,newImage('t22',row.A_Image).settings.selector('t22')),
        getSelector('t21')
        .settings.callback(
            getSelector('t21')
            .settings.callback(
            getSelector('t21')
            .test.selected()
            .success(
                getSelector('t21').unselect(),
                newSelector('x21').settings.add(getImage('t21'))
                    )
                )
              
            )
            ,
        getSelector('t22')
        .settings.callback(
            getSelector('t22')
            .settings.callback(
            getSelector('t22')
            .test.selected()
            .success(
                getSelector('t22').unselect(),
                newSelector('x22').settings.add(getImage('t22'))
                    )
                )
            )
            //,getCanvas('c12').print('center at 33%',350)  
            ,getCanvas('big').settings.add('center at 30%',0,getCanvas('c12'))
            )
        .failure(
            getVar('a')
            .test.is(3)
            .success(
                newCanvas('c13',600,150).settings.css("border", "solid 3px black"),
                newSelector('t31'),
                newSelector('t32'),
                newSelector('t33'),
                getCanvas('c13')
                    .settings.add(0,0,newImage('t31',row.A_Image).settings.selector('t31'))
                    .settings.add(200,0,newImage('t32',row.A_Image).settings.selector('t32'))
                    .settings.add(400,0,newImage('t32',row.A_Image).settings.selector('t33')),
            getSelector('t31')
                .settings.callback(
                    getSelector('t31')
                    .settings.callback(
                        getSelector('t31')
                        .test.selected()
                        .success(
                            getSelector('t31').unselect(),
                            newSelector('x31').settings.add(getImage('t31'))
                                )
                            )
                        )
            ,
                
            getSelector('t32')
            .settings.callback(
                getSelector('t32')
                .settings.callback(
                    getSelector('t32')
                    .test.selected()
                    .success(
                        getSelector('t32').unselect(),
                        newSelector('x32').settings.add(getImage('t32'))
                        )
                    )
                )
            ,
            getSelector('t33')
            .settings.callback(
                getSelector('t33')
                .settings.callback(
                    getSelector('t33')
                    .test.selected()
                    .success(
                        getSelector('t33').unselect(),
                        newSelector('x33').settings.add(getImage('t33'))
                            )
                        )
                    )
            //,getCanvas('c11').print('center at 33%',350)
             ,getCanvas('big').settings.add('center at 30%',0,getCanvas('c13')) 
                )
            )        
        )
    ,
    newVar('b',row.B_set)
    ,
    //newCanvas('c2',750,200)//.settings.css("border", "solid 1px black")
    //,
    getVar('b')
    .test.is(1)
    .success(
        newSelector('t111'),
        newCanvas('c111',200,150).settings.css("border", "solid 3px black")
        .settings.add(0,0,newImage('t111',row.B_Image).settings.selector('t111')),
        getSelector('t111')
        .settings.callback(
            getSelector('t111')
            .settings.callback(
            getSelector('t111')
            .test.selected()
            .success(
                getSelector('t111').unselect(),
                newSelector('x111').settings.add(getImage('t111'))
                    )
                )
            )
        
        ,getCanvas('big').settings.add('center at 62%',0,getCanvas('c111')) 
        )
    .failure(
        getVar('b')
        .test.is(2)
        .success(
            newCanvas('c121',400,150).settings.css("border", "solid 3px black"),
            newSelector('t121'),
            getCanvas('c121')
            .settings.add(0,0,newImage('t121',row.B_Image).settings.selector('t121')),
            getSelector('t121')
        .settings.callback(
            getSelector('t121')
            .settings.callback(
            getSelector('t121')
            .test.selected()
            .success(
                getSelector('t121').unselect(),
                newSelector('x121').settings.add(getImage('t121'))
                    )
                )
            )
            ,
            newSelector('t122'),
            getCanvas('c121')
            .settings.add(200,0,newImage('t122',row.B_Image).settings.selector('t122')),
            getSelector('t122')
        .settings.callback(
            getSelector('t122')
            .settings.callback(
            getSelector('t122')
            .test.selected()
            .success(
                getSelector('t122').unselect(),
                newSelector('x122').settings.add(getImage('t122'))
                    )
                )
            )
            ,getCanvas('big').settings.add('center at 73%',0,getCanvas('c121')) 
            )
        .failure(
            getVar('b')
            .test.is(3)
            .success(
                newCanvas('c131',600,150).settings.css("border", "solid 3px black"),
                newSelector('t131'),
                getCanvas('c131')
                .settings.add(0,0,newImage('t131',row.B_Image).settings.selector('t131')),
                getSelector('t131')
        .settings.callback(
            getSelector('t131')
            .settings.callback(
            getSelector('t131')
            .test.selected()
            .success(
                getSelector('t131').unselect(),
                newSelector('x131').settings.add(getImage('t131'))
                    )
                )
            )
                ,
                newSelector('t132'),
                getCanvas('c131')
                .settings.add(200,0,newImage('t132',row.B_Image).settings.selector('t132')),
                getSelector('t132')
        .settings.callback(
            getSelector('t132')
            .settings.callback(
            getSelector('t132')
            .test.selected()
            .success(
                getSelector('t132').unselect(),
                newSelector('x132').settings.add(getImage('t132'))
                    )
                )
            )
                ,
                newSelector('t133'),
                getCanvas('c131')
                .settings.add(400,0,newImage('t133',row.B_Image).settings.selector('t133')),
                getSelector('t133')
        .settings.callback(
            getSelector('t133')
            .settings.callback(
            getSelector('t133')
            .test.selected()
            .success(
                getSelector('t133').unselect(),
                newSelector('x133').settings.add(getImage('t133'))
                    )
                )
            )
            ,getCanvas('big').settings.add('center at 75%',0,getCanvas('c131')) 
                )
            )        
        )
    ,
    newText('Here are some&nbsp;').settings.after(newText('w1',row.A_set_image).settings.after(newText('&nbsp; and some&nbsp;').settings.after(newText('w2',row.B_set_image).settings.after(newText('.'))))),
    newText('I want&nbsp;').settings.after(newText('trial',row.Trial).settings.after(newText('&nbsp;of the&nbsp;').settings.after(newText('req',row.Requested_item).settings.after(newText('.'))))),


    
    //newCanvas('big',1200,200)
        //.settings.add(0,0,getCanvas('c1'))//.settings.center())//.settings.center()
      //  .settings.add(600,0,getCanvas('c2'))//.settings.center()
        //.settings.css("border", "solid 1px black")
    //    .print()
    getCanvas('big').print('center at 50%',350)   
    ,
  
    

    newButton('continue','Continue')
        .print('center at 50%',700)
        .settings.center()
        .wait()
        


)
//.log(getVar('a')).log(getVar('b'))


)

PennController.Template( 'items.csv',
    row => PennController(
    defaultImage
        .settings.size(200,200)
        .settings.center()
    ,
    defaultText
        .print()
        .settings.center()
        .settings.bold()
    ,
    defaultSelector
        .settings.frame("solid 3px red")
    ,
    newVar('O2',row.O2)
    .test.is(0)
    .success(
        
        newCanvas('c1',400,150)        
            //.print('center at 50%',100)
            ,
            newSelector('t21').settings.frame(),
            getCanvas('c1').settings.css("border", "solid 3px black")//.settings.center()
            .settings.add(0,0,newImage('t21',row.OP+'a.png').settings.selector('t21')),
        getSelector('t21')
        .settings.callback(
            getSelector('t21')
            .settings.callback(
            getSelector('t21')
            .test.selected()
            .success(
                getSelector('t21').unselect(),
                newSelector('x21').settings.add(getImage('t21')).settings.frame()
                    )
                )
            )
            ,
            newSelector('t22').settings.frame(),
            getCanvas('c1')
            .settings.add(200,0,newImage('t22',row.OP+'a.png').settings.selector('t22')),
        getSelector('t22')
        .settings.callback(
            getSelector('t22')
            .settings.callback(
            getSelector('t22')
            .test.selected()
            .success(
                getSelector('t22').unselect(),
                newSelector('x22').settings.add(getImage('t22')).settings.frame()
                    )
                )
            )
            ,
            newCanvas('c2',600,150).settings.css("border", "solid 3px black")
                
            
            ,
            newSelector('t131'),//.settings.frame("dashed 3px black"),
                getCanvas('c2')
                .settings.add(0,0,newImage('t131',row.OP+'b.png').settings.selector('t131')),
                getSelector('t131')
        .settings.callback(
            getSelector('t131')
            .settings.callback(
            getSelector('t131')
            .test.selected()
            .success(
                getSelector('t131').unselect(),
                newSelector('x131').settings.add(getImage('t131'))//.settings.frame()
                    )
                )
            )
                ,
                newSelector('t132'),//.settings.frame(),
                getCanvas('c2')
                .settings.add(200,0,newImage('t132',row.OP+'b.png').settings.selector('t132')),
                getSelector('t132')
        .settings.callback(
            getSelector('t132')
            .settings.callback(
            getSelector('t132')
            .test.selected()
            .success(
                getSelector('t132').unselect(),
                newSelector('x132').settings.add(getImage('t132'))//.settings.frame()
                    )
                )
            )
                ,
                newSelector('t133'),//.settings.frame(),
                getCanvas('c2')
                .settings.add(400,0,newImage('t133',row.OP+'b.png').settings.selector('t133')),
                getSelector('t133')
        .settings.callback(
            getSelector('t133')
            .settings.callback(
            getSelector('t133')
            .test.selected()
            .success(
                getSelector('t133').unselect(),
                newSelector('x133').settings.add(getImage('t133'))//.settings.frame()
                    )
                )
            )
        
        ,
        getCanvas('c1').print('center at 33%',350)
        ,
        getCanvas('c2').print('center at 70%',350)
            
            )
            
            
            
    .failure(
        newCanvas('c3',600,150).settings.css("border", "solid 3px black"),
        
        newSelector('t31'),//.settings.frame(),
                getCanvas('c3')
                .settings.add(0,0,newImage('t31',row.OP+'a.png').settings.selector('t31')),
            getSelector('t31')
            .settings.callback(
            getSelector('t31')
            .settings.callback(
            getSelector('t31')
            .test.selected()
            .success(
                getSelector('t31').unselect(),
                newSelector('x31').settings.add(getImage('t31'))//.settings.frame()
                    )
                )
            )
                ,
                newSelector('t32'),//.settings.frame(),
                getCanvas('c3')
                .settings.add(200,0,newImage('t32',row.OP+'a.png').settings.selector('t32')),
                 getSelector('t32')
            .settings.callback(
            getSelector('t32')
            .settings.callback(
            getSelector('t32')
            .test.selected()
            .success(
                getSelector('t32').unselect(),
                newSelector('x32').settings.add(getImage('t32'))//.settings.frame()
                    )
                )
            )
                ,
                newSelector('t33'),//.settings.frame(),
                getCanvas('c3')
                .settings.add(400,0,newImage('t33',row.OP+'a.png').settings.selector('t33')),
                 getSelector('t33')
            .settings.callback(
            getSelector('t33')
            .settings.callback(
            getSelector('t33')
            .test.selected()
            .success(
                getSelector('t33').unselect(),
                newSelector('x33').settings.add(getImage('t33'))//.settings.frame()
                    )
                )
            )
        ,
        newCanvas('c4',400,150).settings.css("border", "solid 3px black"),
        newSelector('t121'),//.settings.frame(),
            getCanvas('c4')
            .settings.add(0,0,newImage('t121',row.OP+'b.png').settings.selector('t121')),
            getSelector('t121')
        .settings.callback(
            getSelector('t121')
            .settings.callback(
            getSelector('t121')
            .test.selected()
            .success(
                getSelector('t121').unselect(),
                newSelector('x121').settings.add(getImage('t121'))//.settings.frame()
                    )
                )
            )
            ,
            newSelector('t122'),//.settings.frame(),
            getCanvas('c4')
            .settings.add(200,0,newImage('t122',row.OP+'b.png').settings.selector('t122')),
            getSelector('t122')
        .settings.callback(
            getSelector('t122')
            .settings.callback(
            getSelector('t122')
            .test.selected()
            .success(
                getSelector('t122').unselect(),
                newSelector('x122').settings.add(getImage('t122'))//.settings.frame()
                    )
                )
            )
        ,
        getCanvas('c3').print('center at 33%',350)
        ,
        getCanvas('c4').print('center at 70%',350)
        )
    
    
    
    
 ,
   
    newText('Here are some&nbsp;').settings.after(newText('w1',row.Word1).settings.after(newText('&nbsp; and some&nbsp;').settings.after(newText('w2',row.Word2).settings.after(newText('.'))))),
    newText('I want&nbsp;').settings.after(newText('trial',row.Trial).settings.after(newText('&nbsp;of the&nbsp;').settings.after(newText('req',row.Requested).settings.after(newText('.'))))),


    
   
    newButton('continue','Continue')
        .print('center at 50%',700)
        .settings.center()
        .wait()
   


)
)
//.log(getVar('a')).log(getVar('b'))


