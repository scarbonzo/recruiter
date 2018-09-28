import { Candidate } from './../candidate';
import { Review } from './../review';
import { Component, OnInit } from '@angular/core';
import { RecruiterService } from '../recruiter.service';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-candidate',
  templateUrl: './candidate.component.html',
  styleUrls: ['./candidate.component.css']
})
export class CandidateComponent implements OnInit {
  candidates = [];
  selectedCandidateId = '';
  selectedCandidate = null;
  candidateEdited = false;
  creatingNewCandidate = false;
  newCandidate = null;
  reviewingResume = false;
  newReview = new Review();
  reviewers = [];
  selectedReviewerId = '';
  reviewQuestions = [];
  reviewPositions = [];
  reviewPositionId = '';

  constructor(private _recruiterService: RecruiterService) {}

  ngOnInit() {
    this.updateCandidates();
  }

  updateCandidates() {
    this.candidates = [];
    this._recruiterService
      .getCandidates()
      .subscribe(resEventsData => (this.candidates = resEventsData));
  }

  updateCandidate() {
    this._recruiterService
      .getCandidate(this.selectedCandidateId)
      .subscribe(resEventsData => (this.selectedCandidate = resEventsData));
  }

  saveCandidate() {
    this._recruiterService.updateCandidate(this.selectedCandidate).subscribe();
    this.candidateEdited = false;
    this.updateCandidates();
  }

  createCandidate() {
    this.selectedCandidateId = '';
    this.creatingNewCandidate = true;
  }

  cancelCreateCandidate() {
    this.creatingNewCandidate = false;
    this.newCandidate = null;
  }

  addCandidate() {
    this._recruiterService.addCandidate(this.newCandidate).subscribe();
    this.creatingNewCandidate = false;
    this.updateCandidates();
  }

  reviewResume() {
    this._recruiterService
      .getReviewers()
      .subscribe(resEventsData => (this.reviewers = resEventsData));
    this._recruiterService
      .getPositions()
      .subscribe(resEventsData => (this.reviewPositions = resEventsData));
    this.reviewingResume = true;
    this.candidateEdited = false;
  }

  addReview() {}

  cancelReview() {
    this.selectedReviewerId = '';
    this.reviewingResume = false;
    this.newReview = new Review();
  }

  updateReviewer() {}

  getQuestions() {
    this._recruiterService
      .getPositionQuestions(this.reviewPositionId)
      .subscribe(resEventsData => (this.reviewQuestions = resEventsData));
  }
}
