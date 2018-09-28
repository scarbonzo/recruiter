import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { PositionComponent } from './position/position.component';
import { CandidateComponent } from './candidate/candidate.component';
import { ReviewerComponent } from './reviewer/reviewer.component';
import { QuestionComponent } from './question/question.component';
import { ReviewComponent } from './review/review.component';

import { RecruiterService } from './recruiter.service';
import { ReportComponent } from './report/report.component';

@NgModule({
  declarations: [
    AppComponent,
    PositionComponent,
    CandidateComponent,
    ReviewerComponent,
    QuestionComponent,
    ReviewComponent,
    ReportComponent
  ],
  imports: [BrowserModule, FormsModule, HttpModule, ReactiveFormsModule],
  providers: [RecruiterService],
  bootstrap: [AppComponent]
})
export class AppModule {}
