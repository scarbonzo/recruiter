import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class RecruiterService {
  private _url = 'http://recruiter.api.dev.lsnj.org/api/v1/';
  private headers = new Headers({ 'Content-Type': 'application/json' });
  private options = new RequestOptions({ headers: this.headers });

  constructor(private _http: Http) {}

  getCandidates() {
    return this._http
      .get(this._url + 'candidates?take=10000')
      .pipe(map((_response: Response) => _response.json()));
  }

  getCandidate(id: string) {
    return this._http
      .get(this._url + 'candidates/' + id)
      .pipe(map((_response: Response) => _response.json()));
  }

  updateCandidate(candidate) {
    return this._http
      .put(this._url + 'candidates', candidate, this.options)
      .pipe(map((_response: Response) => _response.json()));
  }

  addCandidate(candidate) {
    return this._http
      .post(this._url + 'candidates', candidate, this.options)
      .pipe(map((_response: Response) => _response.json()));
  }

  getPositions() {
    return this._http
      .get(this._url + 'positions')
      .pipe(map((_response: Response) => _response.json()));
  }

  getPosition(id) {
    return this._http
      .get(this._url + 'positions/' + id)
      .pipe(map((_response: Response) => _response.json()));
  }

  updatePosition(position) {
    return this._http
      .put(this._url + 'positions', position, this.options)
      .pipe(map((_response: Response) => _response.json()));
  }

  addPosition(position) {
    return this._http
      .post(this._url + 'positions', JSON.stringify(position), this.options)
      .pipe(map((_response: Response) => _response.json()));
  }

  deletePosition(id) {
    return this._http
      .delete(this._url + 'positions/' + id)
      .pipe(map((_response: Response) => _response.json()));
  }

  getQuestions() {
    return this._http
      .get(this._url + 'questions')
      .pipe(map((_response: Response) => _response.json()));
  }

  getQuestion(id) {
    return this._http
      .get(this._url + 'questions/' + id)
      .pipe(map((_response: Response) => _response.json()));
  }

  getPositionQuestions(positionId) {
    return this._http
      .get(this._url + 'questions/position/' + positionId)
      .pipe(map((_response: Response) => _response.json()));
  }

  updateQuestion(question) {
    return this._http
      .put(this._url + 'questions', question, this.options)
      .pipe(map((_response: Response) => _response.json()));
  }

  addQuestion(question) {
    return this._http
      .post(this._url + 'questions', JSON.stringify(question), this.options)
      .pipe(map((_response: Response) => _response.json()));
  }

  deleteQuestion(id) {
    return this._http
      .delete(this._url + 'questions/' + id)
      .pipe(map((_response: Response) => _response.json()));
  }

  getReviewers() {
    return this._http
      .get(this._url + 'reviewers')
      .pipe(map((_response: Response) => _response.json()));
  }
}
