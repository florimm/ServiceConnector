let componentPosition = [1, 7];
let observer = null;

function emitChange() {
  observer(componentPosition);
}

export function observe(o) {
  if (observer) {
    throw new Error('Multiple observers not implemented.');
  }

  observer = o;
  emitChange();

  return () => {
    observer = null;
  };
}

export function canMoveComponent(toX, toY) {
	return true;
}

export function moveComponent(toX, toY) {
  componentPosition = [toX, toY];
  emitChange();
}