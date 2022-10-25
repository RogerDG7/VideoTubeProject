import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CommentModel } from 'src/app/Models/CommentModel';
import { ApiCommentService } from 'src/app/Services/api-comment.service';

@Component({
  selector: 'app-comments',
  templateUrl: './comments.component.html',
  styleUrls: ['./comments.component.css']
})
export class CommentsComponent implements OnInit {

  @Input()
  videoId: string = '';
  commentsForm: FormGroup;
  commentsDto: CommentModel[] = [];

  constructor(private commentService: ApiCommentService,
    private matSnackBar: MatSnackBar) {
    this.commentsForm = new FormGroup({
      comment: new FormControl(''),
    });
  }

  ngOnInit(): void {
    this.getComments();
  }
  

  postComment() {
    const comment = this.commentsForm.get('comment')?.value;

    const commentDto = {
      "videoID": this.videoId,
      "userID": '5250eaff-06a3-42f3-b840-0d5c356834cb', //quemado por ahora no hay login
      "text": comment
    }

    this.commentService.PostCommentVideo(commentDto).subscribe(() => {
      this.matSnackBar.open("Comentario posteado exitosamente", "OK");

      this.commentsForm.get('comment')?.reset();
      this.getComments();
    })
  }

  getComments() {
    this.commentService.GetComments(this.videoId).subscribe(data => {
      this.commentsDto = <CommentModel[]>data.objectResponse;
    });
  }

}
