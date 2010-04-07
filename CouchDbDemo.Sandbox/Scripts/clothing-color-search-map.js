function(doc) {
    if (doc.EntityType == 'clothes')
        emit(doc.Color, doc);
}