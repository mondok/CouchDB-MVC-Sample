function(doc) {
    if (doc.City) {
        emit([doc.OwnerName, 0], doc);
    } else if (doc.Owner_Id) {
        emit([doc.Owner_Id, 1, doc.PetName], doc);
    }
}