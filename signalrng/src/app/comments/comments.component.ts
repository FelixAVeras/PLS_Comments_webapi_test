import { Comments } from './../models/comment';
import { CommentsService } from './../services/comments.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-comments',
  templateUrl: './comments.component.html',
  styleUrls: ['./comments.component.css']
})
export class CommentsComponent implements OnInit {

  constructor(private commentService: CommentsService) { }

  comments: Comments[] = [];

  ngOnInit(): void {
    this.commentService.startConnection();
    this.commentService.subjectData$.subscribe(data => this.comments.push(data))
  }

  connect() {
    const txtId = document.querySelector('#txt_id') as HTMLInputElement;
    const id = txtId.value;

    this.commentService.addTransferChartDataListener(id);
  }

  send() {
    const txtMessage = document.querySelector('#txt_message') as HTMLInputElement;
    const message = txtMessage.value;
    const txtId = document.querySelector('#txt_id') as HTMLInputElement;
    const id = txtId.value;

    const comment = {
      id: 1,
      body: message
    }
    console.log(comment)
    try {

      this.commentService.SendComment(id, comment).subscribe(console.log);
    } catch (err) {
      console.log(err)
    }
  }


}
