 /************************************************************************/
 /* 添加菜单的伸展收缩                                                                     */
 /************************************************************************/
 $(document).ready(function(){
 $("#switch").click(function(){
 $("#st").slideToggle("slow");
 });
 }); 
  
 /************************************************************************/
 /* GridView表的伸展收缩                                                                     */
 /************************************************************************/
   
$(document).ready(function(){
$("#head1").click(function(){
$("#content1").slideToggle("slow");
});
}); 

$(document).ready(function(){
$("#head2").click(function(){
$("#content2").slideToggle("slow");
});
}); 

$(document).ready(function(){
$("#head3").click(function(){
$("#content3").slideToggle("slow");
});
}); 

$(document).ready(function(){
$("#head4").click(function(){
$("#content4").slideToggle("slow");
});
});
