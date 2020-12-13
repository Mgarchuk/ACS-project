const HOST_URL = "/CommentHub"

window.onload = () => {
    const hubConnection = new signalR.HubConnectionBuilder()
        .withUrl(HOST_URL)
        .withAutomaticReconnect()
        .build();

    hubConnection
        .start()
        .then(() => {
            hubConnection.on('HubEvent', (newComment) => {

                let item = document.getElementById('comments1');
                item.innerHTML = `
               
                    <div class="media">
                                <a class="pull-left" href="#"><img class="media-object" src="https://bootdey.com/img/Content/avatar/avatar1.png" alt=""></a>
                                <div class="media-body">
                                    <h4 class="media-heading">${newComment.author.login}</h4>
                                    <p>${newComment.text}</p>
                                    <ul class="list-unstyled list-inline media-detail pull-left">
                                        <li><i class="fa fa-calendar"></i>${newComment.date}</li>

                                    </ul>
                                   

                                </div>
                     </div>         
             
                ` + item.innerHTML;
            });
        })
}

const startConnaction = () => {
    const hubConnection = new signalR.HubConnectionBuilder()
        .withUrl(HOST_URL)
        .build();

    return this.hubConnection.start();
}