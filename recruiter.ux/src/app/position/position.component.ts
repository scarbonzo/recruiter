import { Component, OnInit } from '@angular/core';
import { RecruiterService } from '../recruiter.service';
import { Position } from './position';

@Component({
  selector: 'app-position',
  templateUrl: './position.component.html',
  styleUrls: ['./position.component.css']
})
export class PositionComponent implements OnInit {
  positions = [];
  selectedPositionId = '';
  selectedPosition = new Position();
  isCreating = false;
  positionEdited = false;
  newPosition = new Position();

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

  updatePosition() {
    this._recruiterService
      .getPosition(this.selectedPositionId)
      .subscribe(resEventsData => (this.selectedPosition = resEventsData));
  }

  savePosition() {
    this.selectedPosition.updated = new Date();
    this._recruiterService.updatePosition(this.selectedPosition).subscribe();
    this.positionEdited = false;
    this.updatePositions();
  }

  createPosition() {
    this.isCreating = true;
    this.selectedPositionId = '';
  }

  cancelCreatePosition() {
    this.isCreating = false;
    this.selectedPositionId = '';
    this.newPosition = new Position();
  }

  addPosition() {
    this.newPosition.created = new Date();
    this._recruiterService
      .addPosition(this.newPosition)
      .subscribe(resEventsData => (this.selectedPositionId = resEventsData));
    this.isCreating = false;
    this.updatePositions();
  }

  deletePosition() {
    this._recruiterService.deletePosition(this.selectedPositionId).subscribe();
    this.selectedPositionId = '';
    this.updatePositions();
  }
}
