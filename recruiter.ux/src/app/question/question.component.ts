import { Component, OnInit } from '@angular/core';
import { RecruiterService } from '../recruiter.service';
import { Question } from './question';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.css']
})
export class QuestionComponent implements OnInit {
  positions = [];
  selectedPositionId = '';
  questions = [];
  selectedQuestionId = '';
  selectedQuestion: Question;
  questionEdited = false;
  isCreating = false;
  newQuestion = new Question();

  constructor(private _recruiterService: RecruiterService) {}

  ngOnInit() {
    this.updatePositions();
  }

  updatePositions() {
    this.positions = [];
    this._recruiterService
      .getPositions()
      .subscribe(resEventsData => (this.positions = resEventsData));
  }

  updateQuestions() {
    this.selectedQuestionId = '';
    this._recruiterService
      .getPositionQuestions(this.selectedPositionId)
      .subscribe(resEventsData => (this.questions = resEventsData));
  }

  updateQuestion() {
    this._recruiterService
      .getQuestion(this.selectedQuestionId)
      .subscribe(resEventsData => (this.selectedQuestion = resEventsData));
  }

  saveQuestion() {
    this.selectedQuestion.updated = new Date();
    this._recruiterService.updateQuestion(this.selectedQuestion).subscribe();
    this.questionEdited = false;
    this.updateQuestions();
  }

  deleteQuestion() {
    this._recruiterService.deletePosition(this.selectedQuestionId).subscribe();
    this.selectedQuestionId = '';
    this.updateQuestions();
  }

  createQuestion() {
    this.isCreating = true;
    this.selectedQuestionId = '';
  }

  cancelCreateQuestion() {
    this.isCreating = false;
    this.selectedQuestionId = '';
    this.newQuestion = new Question();
  }

  addQuestion() {
    this.isCreating = false;
    this.newQuestion.positionId = this.selectedPositionId;
    this.newQuestion.created = new Date();
    this._recruiterService.addQuestion(this.newQuestion).subscribe();
    this.newQuestion = new Question();
    this.updateQuestions();
  }
}
