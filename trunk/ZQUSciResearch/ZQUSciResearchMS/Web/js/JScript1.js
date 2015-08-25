$(document).ready(function(){
	//页面中的DOM已经装载完成时，执行的代码
	$(".main > a").click(function(){
		//找到主菜单项对应的子菜单项
		var ulNode = $(this).next("ul");
		ulNode.slideToggle();
		changeIcon($(this));
	});
});
function changeIcon(mainNode) {
	$("#navigation").addClass("main");
}