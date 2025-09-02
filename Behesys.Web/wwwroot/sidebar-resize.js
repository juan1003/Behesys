window.sidebarResizerMouseDown = function (e) {
    e.preventDefault();
    const sidebar = document.querySelector('.sidebar');
    const startX = e.clientX;
    const startWidth = sidebar.offsetWidth;
    function mouseMoveHandler(ev) {
        const newWidth = startWidth + (ev.clientX - startX);
        sidebar.style.width = newWidth + 'px';
    }
    function mouseUpHandler() {
        document.removeEventListener('mousemove', mouseMoveHandler);
        document.removeEventListener('mouseup', mouseUpHandler);
    }
    document.addEventListener('mousemove', mouseMoveHandler);
    document.addEventListener('mouseup', mouseUpHandler);
};
