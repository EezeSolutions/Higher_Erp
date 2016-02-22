$(document).ready(function() {
	$(".admin-account").click(function() {
		$(".dropdown-menu").slideToggle();
	});
	
	$(".navigation a").hover(function() {
		$(this).next(".dd-menu").slideDown();
	});
	
	$(".navigation a").mouseenter(function() {
		$(this).parent("li").addClass("open");
		});
			$(".navigation a").mouseleave(function() {
			$(this).parent("li").removeClass("open");
		});
		
		$('.dd-menu li').hover(
			function() {
			$(this).find('.dd-menu-child').stop(true, true).delay(100).slideDown();
			}, 
			function() {
			$(this).find('.dd-menu-child').stop(true, true).delay(100).slideUp();
			}
		);
		
		$('.dd-menu-child').hover(
			function() {
			$(this).stop(true, true);
			},
			function() {
			$(this).stop(true, true).delay(100).fadeOut();
			}
		);		
});