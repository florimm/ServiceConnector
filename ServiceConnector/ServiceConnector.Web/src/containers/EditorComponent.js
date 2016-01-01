import React, {Component, PropTypes} from 'react';
import EditorSquare from './EditorSquare';
import ServiceComponent from './../components/ServiceComponent';
import { DragDropContext } from 'react-dnd';
import HTML5Backend from 'react-dnd-html5-backend';


class EditorComponent extends Component{
  renderSquare(i) {
    const x = i % 8;
    const y = Math.floor(i / 8);

    return (
      <div key={i}
           style={{ width: '12.5%', height: '12.5%' }}>

      </div>
    );
  }

  renderPiece(x, y) {
    const [knightX, knightY] = this.props.knightPosition;
    if (x === knightX && y === knightY) {
      return <ServiceComponent group="123" name="2333" />;
    }
  }
    render(){
        const squares = [];
          squares.push(this.renderSquare(1));
        return (
                <section className="content">
                  <div className="box">
                    <div className="box-body">
                      {squares}
                    </div>
                  </div>
                </section>
            );
    }
}

export default DragDropContext(HTML5Backend)(EditorComponent);