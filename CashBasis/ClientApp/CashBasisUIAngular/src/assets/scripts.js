$(document).ready(function(){
	// Activate tooltip
	$('[data-toggle="tooltip"]').tooltip({
		placement: "auto", trigger: 'hover', sanitize: false, sanitizeFn: content => content
	 });

		// Select/Deselect checkboxes
		var checkbox = $('table tbody input[type="checkbox"]');
		$("#selectAll").click(function(){
			if(this.checked){
				checkbox.each(function(){
					this.checked = true;                        
				});
			} else{
				checkbox.each(function(){
					this.checked = false;                        
				});
			} 
		});
		checkbox.click(function(){
			if(!this.checked){
				$("#selectAll").prop("checked", false);
			}
		});
});

